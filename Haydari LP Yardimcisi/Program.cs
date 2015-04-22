using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using LeagueSharp.Common;
using LeagueSharp;
using SharpDX;
using Color = System.Drawing.Color;

namespace Haydari_LP_Yardimcisi
{
    class Program
    {
        private static string wb;
        private static int huloooo = 0;
        private static List<string> camp = new List<string>();
        private static string kirmizi = "<font color = \"#ff052b\">";
        private static string close = "</font>";
        private static string lila = "<font color = \"#39f613\">";
        private static string sari = "<font color = \"#f6d313\">";
        private static string mavi = "<font color = \"#0cf7e4\">";
        private static string sarimsi = "<font color = \"#fbe600\">";
        private static string bembeyaz = "<font color = \"#fcdfff\">";
        private static List<string> lig = new List<string>();
        private static List<string> puan = new List<string>();
        private static List<string> saldiri = new List<string>();
        private static List<string> savunma = new List<string>();
        private static List<string> islevsel = new List<string>();
        private static List<System.Drawing.Color> colores = new List<Color>();
        private static LeagueSharp.Common.Menu haydarigeceler;
        private static Obj_AI_Hero Player { get { return ObjectManager.Player; } }
        private static int miktari = 0;
        static void Main(string[] args)
        {

            CustomEvents.Game.OnGameLoad += Game_OnGameLoad;
            colores.Add(System.Drawing.Color.White);
            colores.Add(System.Drawing.Color.Red);
            colores.Add(System.Drawing.Color.Yellow);
            colores.Add(System.Drawing.Color.SandyBrown);
            colores.Add(System.Drawing.Color.DodgerBlue);
        }


        private static void Game_OnGameLoad(EventArgs args)
        {
            Game.PrintChat("<font color = \"#ff052b\">Haydari LP Yardimcisi</font>  <font color = \"#fcdfff\">Yuklendi  </font> ");

            if (GetRegion() == "hata")
            {
                Game.PrintChat("Haydari LP Yardimcisi KOREA serveri desteklemiyor");
                return;
            }
            haydarigeceler = new LeagueSharp.Common.Menu("Haydari LP Yardimcisi", "", true);
            if (Navegar() == false)
            {
                return;
            };



            var press = haydarigeceler.AddItem(new MenuItem("secenekler", "bilgileri sohbete yaz").SetValue(new KeyBind(76, KeyBindType.Press)));
            haydarigeceler.AddItem(new MenuItem("Bilgiler", "HaydariGeceler tarafindan yazildim desteklerinizi bekleriz:) "));
            haydarigeceler.AddToMainMenu();



            press.ValueChanged += delegate(object sender, OnValueChangeEventArgs EventArgs)
            {




                if (haydarigeceler.Item("secenekler").GetValue<KeyBind>().Active)
                {



                    yazdirmaca();


                }
            };

        }


        static bool Navegar()
        {
            string url = "http://www.lolnexus.com/ajax/get-game-info/" + GetRegion() + ".json?name=" + ObjectManager.Player.Name.Replace(" ", "++");

            wb = new WebClient().DownloadString(url);

            if (wb.Contains("player-name"))
            {

                verial();
                return true;
            }
            else
            {

                huloooo += 1;
                if (huloooo == 5)
                {
                    Game.PrintChat("HAYDARI LP YARDIMCI SUNUCUSU <font color = \"#ff052b\">CALISMIYOR.</font> BIRKAC DAKIKA ICINDE TEKRAR DENEYIN [F5] ");
                    return false;
                }
                Navegar();
                return true;
            }
        }


        static void verial()
        {





            while (wb.Contains("<td class=\\\"champion\\\">"))
            {
                string champ = (GetBetween(wb, "<td class=\\\"champion\\\">\\r\\n        <i class=\\\"icon champions-lol-28", "\\\">"));
                wb = wb.Replace("<td class=\\\"champion\\\">\\r\\n        <i class=\\\"icon champions-lol-28" + champ, " ");
                champ = champ.Replace("\\", "");
                champ = champ.Trim();

                camp.Add(champ);

                string rank = (GetBetween(wb, "class=\\\"champion-ranks", "\\\">"));
                wb = ReplaceFirst(wb, "class=\\\"champion-ranks", "");
                rank = rank.Trim();
                lig.Add(rank);

                string points = (GetBetween(wb, "(<b>", "</b>)"));
                wb = ReplaceFirst(wb, "(<b>", "");
                points = points.Trim();
                points = points.Replace(" ", "");
                puan.Add(points);

                string offense = (GetBetween(wb, "<span class=\\\"offense\\\">", "</span>"));
                wb = ReplaceFirst(wb, "<span class=\\\"offense\\\">", "");
                offense = offense.Trim();
                saldiri.Add(offense + "/");

                string defense = (GetBetween(wb, "<span class=\\\"defense\\\">", "</span>"));
                wb = ReplaceFirst(wb, "<span class=\\\"defense\\\">", "");
                defense = defense.Trim();

                savunma.Add(defense + "/");

                string utility = (GetBetween(wb, "<span class=\\\"utility\\\">", "</span>"));
                wb = ReplaceFirst(wb, "<span class=\\\"utility\\\">", "");
                utility = utility.Trim();
                islevsel.Add(utility);




            }


            Game.PrintChat("<font color = \"#fcdfff\">[HG]VERI HAZIR.</font>");
            Game.PrintChat(bembeyaz + "-->[HG]bilgileri chate yazdir" + close + mavi + " (L) varsayilan" + close);



            miktari = camp.Count;




        }

        static void yazdirmaca()
        {



            for (int i = 0; i < camp.Count; i++)
            {
                if (Player.ChampionName.ToUpper() == camp[i].ToUpper())
                {

                    Game.PrintChat(sarimsi + "-BEN" + close + "--->" + close + lila + lig[i].ToUpper() + " (" + puan[i] + ")" + close + "-->" + sari + saldiri[i] + savunma[i] + islevsel[i] + close);
                    continue;
                }
                if (miktari == 10)
                {


                    if (i >= 5)
                    {
                        Game.PrintChat(mavi + camp[i].ToUpper() + close + "--->" + lila + lig[i].ToUpper() + " (" + puan[i] + ")" + close + "-->" + sari + saldiri[i] + savunma[i] + islevsel[i] + close);

                        continue;
                    }
                }


                if (miktari == 6)
                {
                    if (i >= 3)
                    {
                        Game.PrintChat(mavi + camp[i].ToUpper() + close + "--->" + lila + lig[i].ToUpper() + " (" + puan[i] + ")" + close + "-->" + sari + saldiri[i] + savunma[i] + islevsel[i] + close);
                        continue;
                    }
                }
                Game.PrintChat(kirmizi + camp[i].ToUpper() + close + "--->" + lila + lig[i].ToUpper() + " (" + puan[i] + ")" + close + "-->" + sari + saldiri[i] + savunma[i] + islevsel[i] + close);

            }

        }





        static string ReplaceFirst(string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }


        static string GetBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }
        public static string GetRegion()
        {
            if (Game.Region.ToLower().Contains("na"))
            {
                return "NA";
            }
            if (Game.Region.ToLower().Contains("euw"))
            {
                return "EUW";
            }
            if (Game.Region.ToLower().Contains("eun"))
            {
                return "EUNE";
            }
            if (Game.Region.ToLower().Contains("la1"))
            {
                return "LAN";
            }
            if (Game.Region.ToLower().Contains("la2"))
            {
                return "LAS";
            }
            if (Game.Region.ToLower().Contains("tr"))
            {
                return "TR";
            }
            if (Game.Region.ToLower().Contains("br"))
            {
                return "BR";
            }
            if (Game.Region.ToLower().Contains("ru"))
            {
                return "RU";
            }
            if (Game.Region.ToLower().Contains("kr"))
            {

                return "hata";
            }
            if (Game.Region.ToLower().Contains("oc1"))
            {
                return "OCE";
            }

            return "";

        }
    }


}
