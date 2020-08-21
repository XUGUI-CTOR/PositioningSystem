using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Position_BulletinBoard.Commands
{
    public static class WindowCommands
    {
        private static readonly Lazy<ICommand> closeWindow = new Lazy<ICommand>(CloseWindowCommand);
        private static readonly Lazy<ICommand> minimizeWindow = new Lazy<ICommand>(MinimizeWindowCommand);
        private static readonly Lazy<ICommand> restoreWindow = new Lazy<ICommand>(RestoreWindowCommand);
        private static readonly Lazy<ICommand> maximizeWindow = new Lazy<ICommand>(MaximizeWindowCommand);

        private static ICommand CloseWindowCommand() => new RelayCommand<DependencyObject>(
          sender => GetWindow(sender)?.Close()
        , sender => CanGetWindow(sender));

        private static ICommand MinimizeWindowCommand() => new RelayCommand<DependencyObject>(
          sender => GetWindow(sender)?.MinimizeWindowFunc()
        , sender => CanGetWindow(sender));

        private static ICommand RestoreWindowCommand() => new RelayCommand<DependencyObject>(
          sender => GetWindow(sender)?.RestoreWindowFunc()
        , sender => CanGetWindow(sender));

        private static ICommand MaximizeWindowCommand() => new RelayCommand<DependencyObject>(
          sender => GetWindow(sender)?.MaximizeWindowFunc()
        , sender => CanGetWindow(sender));

        public static void MinimizeWindowFunc(this Window window) => SystemCommands.MinimizeWindow(window);

        public static void RestoreWindowFunc(this Window window) => SystemCommands.RestoreWindow(window);

        public static void MaximizeWindowFunc(this Window window) => SystemCommands.MaximizeWindow(window);

        private static bool CanGetWindow(DependencyObject sender)
        {
            return sender != null && Window.GetWindow(sender) != null;
        }

        private static Window GetWindow(DependencyObject sender)
        {
            Window result = null;
            if (sender != null)
            {
                result = Window.GetWindow(sender);
            }
            return result;
        }

        /// <summary>
        /// Gets the command that close a <see cref="Window"/>.
        /// </summary>
        /// <value>
        /// The command.
        /// </value>
        public static ICommand CloseWindow => closeWindow.Value;

        /// <summary>
        /// Gets the command that minimize a <see cref="Window"/>.
        /// </summary>
        /// <value>
        /// The command.
        /// </value>
        public static ICommand MinimizeWindow => minimizeWindow.Value;

        /// <summary>
        /// Gets the command that restore a <see cref="Window"/>.
        /// </summary>
        /// <value>
        /// The command.
        /// </value>
        public static ICommand RestoreWindow => restoreWindow.Value;

        /// <summary>
        /// Gets the command that maximize a <see cref="Window"/>.
        /// </summary>
        /// <value>
        /// The command.
        /// </value>
        public static ICommand MaximizeWindow => maximizeWindow.Value;
    }
}
