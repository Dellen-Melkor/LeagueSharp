using System;
using LeagueSharp;
using LeagueSharp.Common;


namespace Haydari_IP_Olcer
{
    class Program
    {
        public static bool durus = false;
        public static float oynzmn = 0;
        public static Menu Config;        
        static void Main(string[] args)
        {
            CustomEvents.Game.OnGameLoad += Game_OnGameLoad;
            Game.OnUpdate += OnUpdate;
        }
        public static void Game_OnGameLoad(EventArgs args)
        {
            Game.PrintChat("<font color = \"#ff052b\">Haydari IP Olcer :</font> Yuklendi");
            Config = new Menu("IP Olcer", "IP Olcer", true);
            Config.AddItem(new MenuItem("IPgali", "Kazanınca "));
            Config.AddItem(new MenuItem("IPmaglu", "Kaybedince"));
            Config.AddItem(new MenuItem("IPberaber", "Berabere kalinca"));
            Config.AddItem(new MenuItem("dakika",""));
            Config.AddItem(new MenuItem("Yapimci", "HaydariGeceler Tarafindan " + "Yazildim desteklerinizi beklerim"));
            var press1 = Config.AddItem(new MenuItem("tiklagelsin", "Chate yazdir").SetValue(new KeyBind(85, KeyBindType.Press)));
            Config.AddToMainMenu();
            press1.ValueChanged += delegate(object sender, OnValueChangeEventArgs EventArgs)
            {
                if (Config.Item("tiklagelsin").GetValue<KeyBind>().Active)
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
            Config.Item("IPgali").DisplayName = "Kazandiginda " + kazanip + "  ip gelicek";
            Config.Item("IPmaglu").DisplayName = "Kaybettiginde " + kayipip + "  İp gelcek";
            Config.Item("IPberaber").DisplayName = " Berabere kalınca :" + berabere + " saka saka xD";
            Config.Item("dakika").DisplayName = "dakika :" + dakika;
        }
    }
}