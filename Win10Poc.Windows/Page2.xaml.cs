using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Win10Poc.Windows
{
    public sealed partial class Page2 : Page
    {
        public Page2()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons")) BackButton.Visibility = Visibility.Collapsed;

            SystemNavigationManager.GetForCurrentView().BackRequested += Page2_BackRequested;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            SystemNavigationManager.GetForCurrentView().BackRequested -= Page2_BackRequested;
        }

        private void Page2_BackRequested(object sender, BackRequestedEventArgs e)
        {
            Frame.GoBack();
            e.Handled = true;
        }

        private void StateComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (StateComboBox.SelectedIndex)
            {
                case 0:
                    ResetAlignment();
                    break;
                case 1: // Align Right
                    ResetAlignment();

                    RedGrid.SetValue(RelativePanel.AlignLeftWithPanelProperty, false);
                    BlueGrid.SetValue(RelativePanel.AlignLeftWithPanelProperty, false);
                    GreenGrid.SetValue(RelativePanel.AlignLeftWithPanelProperty, false);

                    RedGrid.SetValue(RelativePanel.AlignRightWithPanelProperty, true);
                    BlueGrid.SetValue(RelativePanel.AlignRightWithPanelProperty, true);
                    GreenGrid.SetValue(RelativePanel.AlignRightWithPanelProperty, true);
                    break;
                case 2: // Align to Each Other
                    ResetAlignment();

                    RedGrid.SetValue(RelativePanel.AlignLeftWithPanelProperty, false);
                    BlueGrid.SetValue(RelativePanel.AlignLeftWithPanelProperty, false);
                    GreenGrid.SetValue(RelativePanel.AlignLeftWithPanelProperty, false);

                    RedGrid.SetValue(RelativePanel.AlignRightWithProperty, GreenGrid);
                    BlueGrid.SetValue(RelativePanel.AlignRightWithProperty, GreenGrid);
                    break;
                case 3: // Relative to Each Other
                    ResetAlignment();

                    BlueGrid.SetValue(RelativePanel.AlignLeftWithPanelProperty, false);
                    GreenGrid.SetValue(RelativePanel.AlignLeftWithPanelProperty, false);

                    BlueGrid.SetValue(RelativePanel.RightOfProperty, RedGrid);
                    GreenGrid.SetValue(RelativePanel.RightOfProperty, BlueGrid);
                    break;
                case 4: // Complex
                    ResetAlignment();

                    RedGrid.SetValue(RelativePanel.AlignLeftWithPanelProperty, false);
                    BlueGrid.SetValue(RelativePanel.AlignLeftWithPanelProperty, false);
                    GreenGrid.SetValue(RelativePanel.AlignLeftWithPanelProperty, false);
                    RedGrid.SetValue(RelativePanel.AlignTopWithPanelProperty, false);
                    BlueGrid.SetValue(RelativePanel.AlignTopWithPanelProperty, false);
                    GreenGrid.SetValue(RelativePanel.AlignTopWithPanelProperty, false);

                    RedGrid.SetValue(RelativePanel.AlignHorizontalCenterWithPanelProperty, true);
                    RedGrid.SetValue(RelativePanel.AlignVerticalCenterWithPanelProperty, true);

                    BlueGrid.SetValue(RelativePanel.RightOfProperty, RedGrid);
                    BlueGrid.SetValue(RelativePanel.BelowProperty, RedGrid);

                    GreenGrid.SetValue(RelativePanel.LeftOfProperty, RedGrid);
                    GreenGrid.SetValue(RelativePanel.AboveProperty, RedGrid);
                    break;
            }
        }

        private void ResetAlignment()
        {
            ResetAlignmentForGrid(BlueGrid);
            ResetAlignmentForGrid(RedGrid);
            ResetAlignmentForGrid(GreenGrid);
        }

        private void ResetAlignmentForGrid(Grid grid)
        {
            if (grid == null) return;
            
            // Align with Panel
            grid.SetValue(RelativePanel.AlignBottomWithPanelProperty, false);
            grid.SetValue(RelativePanel.AlignLeftWithPanelProperty, true);
            grid.SetValue(RelativePanel.AlignRightWithPanelProperty, false);
            grid.SetValue(RelativePanel.AlignTopWithPanelProperty, true);
            grid.SetValue(RelativePanel.AlignHorizontalCenterWithPanelProperty, false);
            grid.SetValue(RelativePanel.AlignVerticalCenterWithPanelProperty, false);

            // Align with Other Controls
            grid.SetValue(RelativePanel.AlignBottomWithProperty, null);
            grid.SetValue(RelativePanel.AlignLeftWithProperty, null);
            grid.SetValue(RelativePanel.AlignRightWithProperty, null);
            grid.SetValue(RelativePanel.AlignTopWithProperty, null);
            grid.SetValue(RelativePanel.AlignHorizontalCenterWithProperty, null);
            grid.SetValue(RelativePanel.AlignVerticalCenterWithProperty, null);

            // Relative to Other Controls
            grid.SetValue(RelativePanel.AboveProperty, null);
            grid.SetValue(RelativePanel.BelowProperty, null);
            grid.SetValue(RelativePanel.RightOfProperty, null);
            grid.SetValue(RelativePanel.LeftOfProperty, null);
        }

        private void BackButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (Frame.CanGoBack) Frame.GoBack();
        }
    }
}
