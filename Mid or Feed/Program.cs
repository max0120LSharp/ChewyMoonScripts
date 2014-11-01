﻿using LeagueSharp;
using LeagueSharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mid_or_Feed
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            CustomEvents.Game.OnGameLoad += Game_OnGameLoad;
        }

        private static void Game_OnGameLoad(EventArgs args)
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
            var plugin = Type.GetType("Mid_or_Feed.Champions." + ObjectManager.Player.ChampionName);
            if (plugin == null) return;

            Activator.CreateInstance(plugin);
        }

        private static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs unhandledExceptionEventArgs)
        {
            Console.WriteLine(((Exception)unhandledExceptionEventArgs.ExceptionObject).Message);
        }
    }
}