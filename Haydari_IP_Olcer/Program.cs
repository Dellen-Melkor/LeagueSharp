using System;
using LeagueSharp;
using LeagueSharp.Common;


namespace Haydari_IP_Olcer
{
    class Program
    {
        public static bool durus = false;
        public static float oynzmn = 0;
        public static Menu haydarimenu;        
        static void Main(string[] args)
        {
            CustomEvents.Game.OnGameLoad += Game_OnGameLoad;
            Game.OnUpdate += OnUpdate;
        }
        public static void Game_OnGameLoad(EventArgs args)
        {
            Game.PrintChat("<font color = \"#ff052b\">Haydari IP Olcer :</font> Yuklendi");
            haydarimenu = new Menu("IP Olcer", "IP Olcer", true);
            haydarimenu.AddItem(new MenuItem("IPgali", "Kazanınca "));
            haydarimenu.AddItem(new MenuItem("IPmaglu", "Kaybedince"));
            haydarimenu.AddItem(new MenuItem("IPberaber", "Berabere kalinca"));
            haydarimenu.AddItem(new MenuItem("dakika",""));
            haydarimenu.AddItem(new MenuItem("Yapimci", "HaydariGeceler Tarafindan " + "Yazildim desteklerinizi beklerim"));
            var press1 = haydarimenu.AddItem(new MenuItem("tiklagelsin", "Chate yazdir").SetValue(new KeyBind(85, KeyBindType.Press)));
            haydarimenu.AddToMainMenu();
            press1.ValueChanged += delegate(object sender, OnValueChangeEventArgs EventArgs)
            {
                if (haydarimenu.Item("tiklagelsin").GetValue<KeyBind>().Active)
                {
                    yazdirmaca();
                }
            };
        }
            static void yazdirmaca()
        {
            double dakika = Game.Time / 60 - 1;
            double kazanip = 18 + 2.312 * dakika;
            double kayipip = 16 + 1.405 * dakika;            
            Game.PrintChat("<font color = \"#39f613\">Kazaninca: </font>" + kazanip + "IP gelicek.");
            Game.PrintChat("<font color = \"#39f613\">Kaybedince: </font>" + kayipip + "IP gelicek.");
            Game.PrintChat("<font color = \"#39f613\">Dakika: </font>" + dakika);
        }                   
        public static void OnUpdate(EventArgs args)
        {
            double dakika = Game.Time / 60 - 1 ;
            double kazanip = 18 + 2.312 * dakika;
            double kayipip = 16 + 1.405 * dakika;
            double berabere = 1881 + 1881 * 1453;
            haydarimenu.Item("IPgali").DisplayName = "Kazandiginda " + kazanip + "  ip gelicek";
            haydarimenu.Item("IPmaglu").DisplayName = "Kaybettiginde " + kayipip + "  İp gelcek";
            haydarimenu.Item("IPberaber").DisplayName = " Berabere kalınca :" + berabere + " saka saka xD";
            haydarimenu.Item("dakika").DisplayName = "dakika :" + dakika;
        }
    }
}