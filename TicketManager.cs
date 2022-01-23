using AntMe.Deutsch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AntMe.Player.Ameisen
{
    public class TicketManager
    {
        private static TicketManager _instance;
        private List<Zucker> _zuckerList = new List<Zucker>();
        private List<RoccosAmeise> _ameisen = new List<RoccosAmeise>();
        private Queue<Ticket> _tickets = new Queue<Ticket>();

        public static TicketManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TicketManager();
                }
                return _instance;
            }
        }

        internal void RegistriereZucker(Zucker zucker)
        {
            if (!_zuckerList.Contains(zucker))
            {
                var maximaleLast = _ameisen.First().MaximaleLast;
                _zuckerList.Add(zucker);
                var anzahlTickets = zucker.Menge / maximaleLast;
                for (var i = 0; i < anzahlTickets; i++)
                {
                    _tickets.Enqueue(new Ticket(zucker));
                }
            }
        }

        internal void RegistriereAmeise(RoccosAmeise ameise)
        {
            if (!_ameisen.Contains(ameise))
                _ameisen.Add(ameise);

        }
        internal void UnRegistriereAmeise(RoccosAmeise ameise)
        {
            _ameisen.Remove(ameise);
        }

        internal Ticket GetTicket()
        {
            if(_tickets.Count > 0)
            {
                return _tickets.Dequeue();
            }
            return null;
        }
    }
}



