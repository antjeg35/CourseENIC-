using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP1Module5LesChats.Models
{
    public class Data
    {
        private static Data _instance;
        
        static readonly object instanceLock = new object();

        private Data()
        {
            InitialisationData();
        }

        public static Data Instance
        {
            get
            {
                if (_instance == null) 
                {
                    lock (instanceLock)
                    {
                        if (_instance == null) 
                            _instance = new Data();
                    }
                }
                return _instance;
            }
        }

        private List<Chat> listeChats= new List<Chat>();

        public List<Chat> ListeChats
        {
            get { return listeChats; }
            set { listeChats = value; }
        }

        private void InitialisationData()
        {
            listeChats = Chat.GetMeuteDeChats();
        }
    }
}