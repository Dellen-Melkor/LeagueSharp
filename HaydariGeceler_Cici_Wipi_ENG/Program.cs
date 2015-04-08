using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp;
using LeagueSharp.Common;

namespace HaydariGeceler_cici_wipi_ENG
{
    internal class Program
    {
        private static LeagueSharp.Common.Menu haydarigeceler;
        public static bool duramk = false;
        public static float gameTime1 = 0;

        private static void Main(string[] args)
        {
            CustomEvents.Game.OnGameLoad += Game_OnGameLoad;
        }
        private static void Game_OnGameLoad(EventArgs args)
        {
        Game.PrintChat(
                "<font color = \"#ff052b\">HaydariGeceler cici wipi</font>  <font color = \"#fcdfff\">Loaded  </font> ");

            haydarigeceler = new LeagueSharp.Common.Menu("HaydariGeceler cici wipi", "", true);
            var press =
                haydarigeceler.AddItem(new MenuItem("GGyaz", "Write GG").SetValue(new KeyBind(37, KeyBindType.Press)));
            haydarigeceler.AddItem(new MenuItem("İnfo", "Writed By HaydariGeceler, thanks to everyone for the support:)"));
            haydarigeceler.AddToMainMenu();


            press.ValueChanged += delegate(object sender, OnValueChangeEventArgs EventArgs)
            {
                if (haydarigeceler.Item("GGyaz").GetValue<KeyBind>().Active)
                    if (duramk == false)
                    {
                        
                        Game.Say("/all   ######        ######   ");
                        Game.Say("/all  ##                  ##       ");
                        Game.Say("/all  ##                  ##       ");
                        Game.Say("/all  ##   ####     ##   ####");
                        Game.Say("/all  ##        ##     ##       ##");
                        Game.Say("/all  ##        ##     ##       ##");
                        Game.Say("/all   ######        ######  ");
                        duramk = true;
                        gameTime1 = Game.Time + 1;
                        
                    }
                if (Game.Time > gameTime1)
                {
                    duramk = false;
                }
            };
        }
    }
}
          

            
        

        
        
            
        
            


       