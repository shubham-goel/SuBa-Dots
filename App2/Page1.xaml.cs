using App2.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace App2
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class Page1 : Page
    {

        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        /// <summary>
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// NavigationHelper is used on each page to aid in navigation and 
        /// process lifetime management
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }


        public Page1()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;
            
        }

        /// <summary>
        /// Populates the page with content passed during navigation. Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session. The state will be null the first time a page is visited.</param>
        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>

        int super_score = 0;
        int bat_score = 0;
        int curr_turn = 1;

        

        private void update_scores()
        {
            sscore.Text = super_score.ToString();
            bscore.Text = bat_score.ToString();
            if ((super_score + bat_score) == 30)
            {

                if (super_score > bat_score) { super_wins.Opacity = 0.25; }
                else if (super_score < bat_score) { bat_wins.Opacity = 0.4; }
                else { super_wins.Opacity = 0.3; bat_wins.Opacity = 0.5; }
                
                //this.Frame.Navigate(typeof(MainPage));
            }
            

            return;
        }

        private void Curr_Player_anim()
        {
            if (curr_turn == 1)
            {
                s_bg.Opacity = 1;
                b_bg.Opacity = 0;
            }
            else
            {
                s_bg.Opacity = 0;
                b_bg.Opacity = 1;
            }
        }


        private bool is_tile_complete(int tile_number)
        {
            switch (tile_number)
            {
                case 1: if (b1.Opacity == 1 && b3.Opacity == 1 && b4.Opacity == 1 && b5.Opacity == 1 && b6.Opacity == 1) return true; break;
                case 2: if (b4.Opacity == 1 && b7.Opacity == 1 && b8.Opacity == 1 && b9.Opacity == 1 && b10.Opacity == 1) return true; break;
                case 3: if (b5.Opacity == 1 && b10.Opacity == 1 && b20.Opacity == 1 && b22.Opacity == 1 && b35.Opacity == 1) return true; break;
                case 4: if (b23.Opacity == 1 && b34.Opacity == 1 && b35.Opacity == 1 && b36.Opacity == 1 && b37.Opacity == 1) return true; break;
                case 5: if (b33.Opacity == 1 && b38.Opacity == 1 && b40.Opacity == 1 && b39.Opacity == 1 && b41.Opacity == 1) return true; break;
                case 6: if (b24.Opacity == 1 && b31.Opacity == 1 && b32.Opacity == 1 && b33.Opacity == 1 && b34.Opacity == 1) return true; break;
                case 7: if (b30.Opacity == 1 && b32.Opacity == 1 && b41.Opacity == 1 && b42.Opacity == 1 && b43.Opacity == 1) return true; break;
                case 8: if (b43.Opacity == 1 && b44.Opacity == 1 && b45.Opacity == 1 && b46.Opacity == 1 && b47.Opacity == 1) return true; break;
                case 9: if (b27.Opacity == 1 && b28.Opacity == 1 && b29.Opacity == 1 && b30.Opacity == 1 && b31.Opacity == 1) return true; break;
                case 10: if (b21.Opacity == 1 && b22.Opacity == 1 && b23.Opacity == 1 && b24.Opacity == 1 && b25.Opacity == 1) return true; break;
                case 11: if (b9.Opacity == 1 && b17.Opacity == 1 && b18.Opacity == 1 && b19.Opacity == 1 && b20.Opacity == 1) return true; break;
                case 12: if (b14.Opacity == 1 && b17.Opacity == 1 && b16.Opacity == 1 && b017.Opacity == 1 && b014.Opacity == 1) return true; break;
                case 13: if (b8.Opacity == 1 && b11.Opacity == 1 && b12.Opacity == 1 && b13.Opacity == 1 && b14.Opacity == 1) return true; break;
                case 14: if (b13.Opacity == 1 && b15.Opacity == 1 && b16.Opacity == 1 && b015.Opacity == 1 && b013.Opacity == 1) return true; break;
                case 15: if (b013.Opacity == 1 && b014.Opacity == 1 && b012.Opacity == 1 && b011.Opacity == 1 && b08.Opacity == 1) return true; break;
                case 16: if (b08.Opacity == 1 && b07.Opacity == 1 && b09.Opacity == 1 && b010.Opacity == 1 && b04.Opacity == 1) return true; break;
                case 17: if (b09.Opacity == 1 && b18.Opacity == 1 && b017.Opacity == 1 && b019.Opacity == 1 && b020.Opacity == 1) return true; break;
                case 18: if (b19.Opacity == 1 && b21.Opacity == 1 && b26.Opacity == 1 && b019.Opacity == 1 && b021.Opacity == 1) return true; break;
                case 19: if (b25.Opacity == 1 && b26.Opacity == 1 && b27.Opacity == 1 && b027.Opacity == 1 && b025.Opacity == 1) return true; break;
                case 20: if (b28.Opacity == 1 && b027.Opacity == 1 && b029.Opacity == 1 && b031.Opacity == 1 && b030.Opacity == 1) return true; break;
                case 21: if (b29.Opacity == 1 && b47.Opacity == 1 && b49.Opacity == 1 && b029.Opacity == 1 && b047.Opacity == 1) return true; break;
                case 22: if (b46.Opacity == 1 && b48.Opacity == 1 && b046.Opacity == 1 && b048.Opacity == 1 && b49.Opacity == 1) return true; break;
                case 23: if(b043.Opacity == 1 && b044.Opacity == 1 && b045.Opacity == 1 && b046.Opacity == 1 && b047.Opacity == 1) return true; break;
                case 24: if (b030.Opacity == 1 && b032.Opacity == 1 && b041.Opacity == 1 && b042.Opacity == 1 && b043.Opacity == 1) return true; break;
                case 25: if (b033.Opacity == 1 && b038.Opacity == 1 && b040.Opacity == 1 && b039.Opacity == 1 && b041.Opacity == 1) return true; break;
                case 26: if (b024.Opacity == 1 && b031.Opacity == 1 && b032.Opacity == 1 && b033.Opacity == 1 && b034.Opacity == 1) return true; break;
                case 27: if (b021.Opacity == 1 && b022.Opacity == 1 && b023.Opacity == 1 && b024.Opacity == 1 && b025.Opacity == 1) return true; break;
                case 28: if (b023.Opacity == 1 && b034.Opacity == 1 && b035.Opacity == 1 && b036.Opacity == 1 && b037.Opacity == 1) return true; break;
                case 29: if (b05.Opacity == 1 && b010.Opacity == 1 && b020.Opacity == 1 && b022.Opacity == 1 && b035.Opacity == 1) return true; break;
                case 30: if (b01.Opacity == 1 && b03.Opacity == 1 && b04.Opacity == 1 && b05.Opacity == 1 && b06.Opacity == 1) return true; break;
                default: break;
            }
            return false;
        }



        private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region NavigationHelper registration

        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// 
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="GridCS.Common.NavigationHelper.LoadState"/>
        /// and <see cref="GridCS.Common.NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private void click_b1(object sender, RoutedEventArgs e)
        {
            if (b1.Opacity == 1)
                return;
            b1.Opacity = 1;
            
            if (b3.Opacity == 1 && b4.Opacity == 1 && b5.Opacity == 1 && b6.Opacity == 1) 
            {
                if (curr_turn == 1)
                {
                    slogo_1.Opacity = 1;
                    stile_1.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_1.Opacity = 1;
                    btile_1.Opacity = 1;
                    bat_score++;
                }
                update_scores();
            }
            else { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }

        

        private void click_b3(object sender, RoutedEventArgs e)
        {
            if (b3.Opacity == 1)
                return;
            b3.Opacity = 1;
            if (b1.Opacity == 1 && b4.Opacity == 1 && b5.Opacity == 1 && b6.Opacity == 1)
            {
                if (curr_turn == 1)
                {
                    slogo_1.Opacity = 1;
                    stile_1.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_1.Opacity = 1;
                    btile_1.Opacity = 1;
                    bat_score++;
                }
                update_scores();
            }
            else { curr_turn = 3 - curr_turn;}
            Curr_Player_anim();
        }

        private void click_b4(object sender, RoutedEventArgs e)
        {
            if (b4.Opacity == 1)
                return;
            b4.Opacity = 1;
            bool pent_made=false;

            if (b1.Opacity == 1 && b3.Opacity == 1 && b5.Opacity == 1 && b6.Opacity == 1) 
            {
                if (curr_turn == 1)
                {
                    slogo_1.Opacity = 1;
                    stile_1.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_1.Opacity = 1;
                    btile_1.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if(b7.Opacity == 1 && b8.Opacity == 1 && b9.Opacity == 1 && b10.Opacity == 1)
            {
                if (curr_turn == 1)
                {
                    slogo_2.Opacity = 1;
                    stile_2.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_2.Opacity = 1;
                    btile_2.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if(!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }

        private void click_b5(object sender, RoutedEventArgs e)
        {
            if (b5.Opacity == 1)
                return;
            b5.Opacity = 1;
            bool pent_made = false;

            if (b1.Opacity == 1 && b3.Opacity == 1 && b4.Opacity == 1 && b6.Opacity == 1)
            {
                if (curr_turn == 1)
                {
                    slogo_1.Opacity = 1;
                    stile_1.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_1.Opacity = 1;
                    btile_1.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (b10.Opacity == 1 && b35.Opacity == 1 && b20.Opacity == 1 && b22.Opacity == 1)
            {
                if (curr_turn == 1)
                {
                    slogo_3.Opacity = 1;
                    stile_3.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_3.Opacity = 1;
                    btile_3.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }

        private void click_b6(object sender, RoutedEventArgs e)
        {
            if (b6.Opacity == 1)
                return;
            b6.Opacity = 1;
            if (b1.Opacity == 1 && b3.Opacity == 1 && b5.Opacity == 1 && b4.Opacity == 1)
            {
                if (curr_turn == 1)
                {
                    slogo_1.Opacity = 1;
                    stile_1.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_1.Opacity = 1;
                    btile_1.Opacity = 1;
                    bat_score++;
                }
                update_scores();
            }
            else { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }

        private void click_b7(object sender, RoutedEventArgs e)
        {
            if (b7.Opacity == 1)
                return;
            b7.Opacity = 1;

            if (b4.Opacity == 1 && b10.Opacity == 1 && b8.Opacity == 1 && b9.Opacity == 1)
            {
                if (curr_turn == 1)
                {
                    slogo_2.Opacity = 1;
                    stile_2.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_2.Opacity = 1;
                    btile_2.Opacity = 1;
                    bat_score++;
                }
                update_scores();
            }
            else { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }

        private void click_b8(object sender, RoutedEventArgs e)
        {
            if (b8.Opacity == 1)
                return;
            b8.Opacity = 1;

            bool pent_made = false;

            if (b11.Opacity == 1 && b12.Opacity == 1 && b13.Opacity == 1 && b14.Opacity == 1)
            {
                if (curr_turn == 1)
                {
                    slogo_13.Opacity = 1;
                    stile_13.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_13.Opacity = 1;
                    btile_13.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (b7.Opacity == 1 && b4.Opacity == 1 && b9.Opacity == 1 && b10.Opacity == 1)
            {
                if (curr_turn == 1)
                {
                    slogo_2.Opacity = 1;
                    stile_2.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_2.Opacity = 1;
                    btile_2.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }

        private void click_b9(object sender, RoutedEventArgs e)
        {
            if (b9.Opacity == 1)
                return;
            b9.Opacity = 1;

            bool pent_made = false;

            if (is_tile_complete(11))
            {
                if (curr_turn == 1)
                {
                    slogo_11.Opacity = 1;
                    stile_11.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_11.Opacity = 1;
                    btile_11.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (is_tile_complete(2))
            {
                if (curr_turn == 1)
                {
                    slogo_2.Opacity = 1;
                    stile_2.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_2.Opacity = 1;
                    btile_2.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }

        private void click_b10(object sender, RoutedEventArgs e)
        {
            if (b10.Opacity == 1)
                return;
            b10.Opacity = 1;

            bool pent_made = false;

            if (is_tile_complete(2))
            {
                if (curr_turn == 1)
                {
                    slogo_2.Opacity = 1;
                    stile_2.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_2.Opacity = 1;
                    btile_2.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (is_tile_complete(3))
            {
                if (curr_turn == 1)
                {
                    slogo_3.Opacity = 1;
                    stile_3.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_3.Opacity = 1;
                    btile_3.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }

        private void click_b11(object sender, RoutedEventArgs e)
        {
            if (b11.Opacity == 1)
                return;
            b11.Opacity = 1;
            if (is_tile_complete(13))
            {
                if (curr_turn == 1)
                {
                    slogo_13.Opacity = 1;
                    stile_13.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_13.Opacity = 1;
                    btile_13.Opacity = 1;
                    bat_score++;
                }
                update_scores();
            }
            else { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }
        private void click_b12(object sender, RoutedEventArgs e)
        {
            if (b12.Opacity == 1)
                return;
            b12.Opacity = 1;
            if (is_tile_complete(13))
            {
                if (curr_turn == 1)
                {
                    slogo_13.Opacity = 1;
                    stile_13.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_13.Opacity = 1;
                    btile_13.Opacity = 1;
                    bat_score++;
                }
                update_scores();
            }
            else { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }

        private void click_b13(object sender, RoutedEventArgs e)
        {
            if (b13.Opacity == 1)
                return;
            b13.Opacity = 1;

            bool pent_made = false;

            if (is_tile_complete(13))
            {
                if (curr_turn == 1)
                {
                    slogo_13.Opacity = 1;
                    stile_13.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_13.Opacity = 1;
                    btile_13.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (is_tile_complete(14))
            {
                if (curr_turn == 1)
                {
                    slogo_14.Opacity = 1;
                    stile_14.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_14.Opacity = 1;
                    btile_14.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }

        private void click_b14(object sender, RoutedEventArgs e)
        {
            if (b14.Opacity == 1)
                return;
            b14.Opacity = 1;

            bool pent_made = false;

            if (is_tile_complete(12))
            {
                if (curr_turn == 1)
                {
                    slogo_12.Opacity = 1;
                    stile_12.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_12.Opacity = 1;
                    btile_12.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (is_tile_complete(13))
            {
                if (curr_turn == 1)
                {
                    slogo_13.Opacity = 1;
                    stile_13.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_13.Opacity = 1;
                    btile_13.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }

        
        private void click_b15(object sender, RoutedEventArgs e)
        {
            if (b15.Opacity == 1)
                return;
            b15.Opacity = 1;

            if (is_tile_complete(14))
            {
                if (curr_turn == 1)
                {
                    slogo_14.Opacity = 1;
                    stile_14.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_14.Opacity = 1;
                    btile_14.Opacity = 1;
                    bat_score++;
                }
                update_scores();
            }
            else { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();

        }


        private void click_b16(object sender, RoutedEventArgs e)
        {
            if (b16.Opacity == 1)
                return;
            b16.Opacity = 1;

            bool pent_made = false;

            if (is_tile_complete(12))
            {
                if (curr_turn == 1)
                {
                    slogo_12.Opacity = 1;
                    stile_12.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_12.Opacity = 1;
                    btile_12.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (is_tile_complete(14))
            {
                if (curr_turn == 1)
                {
                    slogo_14.Opacity = 1;
                    stile_14.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_14.Opacity = 1;
                    btile_14.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }

        private void click_b17(object sender, RoutedEventArgs e)
        {
            if (b17.Opacity == 1)
                return;
            b17.Opacity = 1;
            bool pent_made = false;

            if (is_tile_complete(12))
            {
                if (curr_turn == 1)
                {
                    slogo_12.Opacity = 1;
                    stile_12.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_12.Opacity = 1;
                    btile_12.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (is_tile_complete(11))
            {
                if (curr_turn == 1)
                {
                    slogo_11.Opacity = 1;
                    stile_11.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_11.Opacity = 1;
                    btile_11.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }

        private void click_b18(object sender, RoutedEventArgs e)
        {
            if (b18.Opacity == 1)
                return;
            b18.Opacity = 1;
            bool pent_made = false;

            if (is_tile_complete(11))
            {
                if (curr_turn == 1)
                {
                    slogo_11.Opacity = 1;
                    stile_11.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_11.Opacity = 1;
                    btile_11.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (is_tile_complete(17))
            {
                if (curr_turn == 1)
                {
                    slogo_17.Opacity = 1;
                    stile_17.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_17.Opacity = 1;
                    btile_17.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }

        private void click_b19(object sender, RoutedEventArgs e)
        {
            if (b19.Opacity == 1)
                return;
            b19.Opacity = 1;
            bool pent_made = false;

            if (is_tile_complete(11))
            {
                if (curr_turn == 1)
                {
                    slogo_11.Opacity = 1;
                    stile_11.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_11.Opacity = 1;
                    btile_11.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (is_tile_complete(18))
            {
                if (curr_turn == 1)
                {
                    slogo_18.Opacity = 1;
                    stile_18.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_18.Opacity = 1;
                    btile_18.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }

        private void click_b20(object sender, RoutedEventArgs e)
        {
            if (b20.Opacity == 1)
                return;
            b20.Opacity = 1;
            bool pent_made = false;

            if (is_tile_complete(11))
            {
                if (curr_turn == 1)
                {
                    slogo_11.Opacity = 1;
                    stile_11.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_11.Opacity = 1;
                    btile_11.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (is_tile_complete(3))
            {
                if (curr_turn == 1)
                {
                    slogo_3.Opacity = 1;
                    stile_3.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_3.Opacity = 1;
                    btile_3.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }

        private void click_b21(object sender, RoutedEventArgs e)
        {
            if (b21.Opacity == 1)
                return;
            b21.Opacity = 1;

            bool pent_made = false;

            if (is_tile_complete(18))
            {
                if (curr_turn == 1)
                {
                    slogo_18.Opacity = 1;
                    stile_18.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_18.Opacity = 1;
                    btile_18.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (is_tile_complete(10))
            {
                if (curr_turn == 1)
                {
                    slogo_10.Opacity = 1;
                    stile_10.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_10.Opacity = 1;
                    btile_10.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }

        private void click_b22(object sender, RoutedEventArgs e)
        {
            if (b22.Opacity == 1)
                return;
            b22.Opacity = 1;
            bool pent_made = false;

            if (is_tile_complete(10))
            {
                if (curr_turn == 1)
                {
                    slogo_10.Opacity = 1;
                    stile_10.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_10.Opacity = 1;
                    btile_10.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (is_tile_complete(3))
            {
                if (curr_turn == 1)
                {
                    slogo_3.Opacity = 1;
                    stile_3.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_3.Opacity = 1;
                    btile_3.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }

        private void click_b23(object sender, RoutedEventArgs e)
        {
            if (b23.Opacity == 1)
                return;
            b23.Opacity = 1;

            bool pent_made = false;

            if (is_tile_complete(4))
            {
                if (curr_turn == 1)
                {
                    slogo_4.Opacity = 1;
                    stile_4.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_4.Opacity = 1;
                    btile_4.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (is_tile_complete(10))
            {
                if (curr_turn == 1)
                {
                    slogo_10.Opacity = 1;
                    stile_10.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_10.Opacity = 1;
                    btile_10.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }

        private void click_b24(object sender, RoutedEventArgs e)
        {
            if (b24.Opacity == 1)
                return;
            b24.Opacity = 1;

            bool pent_made = false;

            if (is_tile_complete(6))
            {
                if (curr_turn == 1)
                {
                    slogo_6.Opacity = 1;
                    stile_6.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_6.Opacity = 1;
                    btile_6.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (is_tile_complete(10))
            {
                if (curr_turn == 1)
                {
                    slogo_10.Opacity = 1;
                    stile_10.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_10.Opacity = 1;
                    btile_10.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }

        private void click_b25(object sender, RoutedEventArgs e)
        {
            if (b25.Opacity == 1)
                return;
            b25.Opacity = 1;
            bool pent_made = false;

            if (is_tile_complete(10))
            {
                if (curr_turn == 1)
                {
                    slogo_10.Opacity = 1;
                    stile_10.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_10.Opacity = 1;
                    btile_10.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (is_tile_complete(19))
            {
                if (curr_turn == 1)
                {
                    slogo_19.Opacity = 1;
                    stile_19.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_19.Opacity = 1;
                    btile_19.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }

        private void click_b26(object sender, RoutedEventArgs e)
        {
            if (b26.Opacity == 1)
                return;
            b26.Opacity = 1;

            bool pent_made = false;

            if (is_tile_complete(18))
            {
                if (curr_turn == 1)
                {
                    slogo_18.Opacity = 1;
                    stile_18.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_18.Opacity = 1;
                    btile_18.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (is_tile_complete(19))
            {
                if (curr_turn == 1)
                {
                    slogo_19.Opacity = 1;
                    stile_19.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_19.Opacity = 1;
                    btile_19.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }

        private void click_b27(object sender, RoutedEventArgs e)
        {
            if (b27.Opacity == 1)
                return;
            b27.Opacity = 1;
            bool pent_made = false;

            if (is_tile_complete(19))
            {
                if (curr_turn == 1)
                {
                    slogo_19.Opacity = 1;
                    stile_19.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_19.Opacity = 1;
                    btile_19.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (is_tile_complete(9))
            {
                if (curr_turn == 1)
                {
                    slogo_9.Opacity = 1;
                    stile_9.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_9.Opacity = 1;
                    btile_9.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }

        private void click_b28(object sender, RoutedEventArgs e)
        {
            if (b28.Opacity == 1)
                return;
            b28.Opacity = 1;
            bool pent_made = false;

            if (is_tile_complete(9))
            {
                if (curr_turn == 1)
                {
                    slogo_9.Opacity = 1;
                    stile_9.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_9.Opacity = 1;
                    btile_9.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (is_tile_complete(20))
            {
                if (curr_turn == 1)
                {
                    slogo_20.Opacity = 1;
                    stile_20.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_20.Opacity = 1;
                    btile_20.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }

        private void click_b29(object sender, RoutedEventArgs e)
        {
            if (b29.Opacity == 1)
                return;
            b29.Opacity = 1;

            bool pent_made = false;

            if (is_tile_complete(9))
            {
                if (curr_turn == 1)
                {
                    slogo_9.Opacity = 1;
                    stile_9.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_9.Opacity = 1;
                    btile_9.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (is_tile_complete(21))
            {
                if (curr_turn == 1)
                {
                    slogo_21.Opacity = 1;
                    stile_21.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_21.Opacity = 1;
                    btile_21.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }

        private void click_b30(object sender, RoutedEventArgs e)
        {
            if (b30.Opacity == 1)
                return;
            b30.Opacity = 1;

            bool pent_made = false;

            if (is_tile_complete(7))
            {
                if (curr_turn == 1)
                {
                    slogo_7.Opacity = 1;
                    stile_7.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_7.Opacity = 1;
                    btile_7.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (is_tile_complete(9))
            {
                if (curr_turn == 1)
                {
                    slogo_9.Opacity = 1;
                    stile_9.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_9.Opacity = 1;
                    btile_9.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }

        private void click_b31(object sender, RoutedEventArgs e)
        {
            if (b31.Opacity == 1)
                return;
            b31.Opacity = 1;
            bool pent_made = false;

            if (is_tile_complete(6))
            {
                if (curr_turn == 1)
                {
                    slogo_6.Opacity = 1;
                    stile_6.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_6.Opacity = 1;
                    btile_6.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (is_tile_complete(9))
            {
                if (curr_turn == 1)
                {
                    slogo_9.Opacity = 1;
                    stile_9.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_9.Opacity = 1;
                    btile_9.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }

        private void click_b32(object sender, RoutedEventArgs e)
        {
            if (b32.Opacity == 1)
                return;
            b32.Opacity = 1;
            bool pent_made = false;

            if (is_tile_complete(6))
            {
                if (curr_turn == 1)
                {
                    slogo_6.Opacity = 1;
                    stile_6.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_6.Opacity = 1;
                    btile_6.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (is_tile_complete(7))
            {
                if (curr_turn == 1)
                {
                    slogo_7.Opacity = 1;
                    stile_7.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_7.Opacity = 1;
                    btile_7.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }

        private void click_b33(object sender, RoutedEventArgs e)
        {
            if (b33.Opacity == 1)
                return;
            b33.Opacity = 1;
            bool pent_made = false;

            if (is_tile_complete(5))
            {
                if (curr_turn == 1)
                {
                    slogo_5.Opacity = 1;
                    stile_5.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_5.Opacity = 1;
                    btile_5.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (is_tile_complete(6))
            {
                if (curr_turn == 1)
                {
                    slogo_6.Opacity = 1;
                    stile_6.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_6.Opacity = 1;
                    btile_6.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }



        private void click_b34(object sender, RoutedEventArgs e)
        {
            if (b34.Opacity == 1)
                return;
            b34.Opacity = 1;
            bool pent_made = false;

            if (is_tile_complete(4))
            {
                if (curr_turn == 1)
                {
                    slogo_4.Opacity = 1;
                    stile_4.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_4.Opacity = 1;
                    btile_4.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (is_tile_complete(6))
            {
                if (curr_turn == 1)
                {
                    slogo_6.Opacity = 1;
                    stile_6.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_6.Opacity = 1;
                    btile_6.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();

        }

        private void click_b35(object sender, RoutedEventArgs e)
        {
            if (b35.Opacity == 1)
                return;
            b35.Opacity = 1;
            bool pent_made = false;

            if (is_tile_complete(3))
            {
                if (curr_turn == 1)
                {
                    slogo_3.Opacity = 1;
                    stile_3.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_3.Opacity = 1;
                    btile_3.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (is_tile_complete(4))
            {
                if (curr_turn == 1)
                {
                    slogo_4.Opacity = 1;
                    stile_4.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_4.Opacity = 1;
                    btile_4.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();

        }

        private void click_b36(object sender, RoutedEventArgs e)
        {
            if (b36.Opacity == 1)
                return;
            b36.Opacity = 1;
            if (is_tile_complete(4))
            {
                if (curr_turn == 1)
                {
                    slogo_4.Opacity = 1;
                    stile_4.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_4.Opacity = 1;
                    btile_4.Opacity = 1;
                    bat_score++;
                }
                update_scores();
            }
            else { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();

        }

        private void click_b37(object sender, RoutedEventArgs e)
        {
            if (b37.Opacity == 1)
                return;
            b37.Opacity = 1;
            
            if (is_tile_complete(4))
            {
                if (curr_turn == 1)
                {
                    slogo_4.Opacity = 1;
                    stile_4.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_4.Opacity = 1;
                    btile_4.Opacity = 1;
                    bat_score++;
                }
                update_scores();
            }
            else { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();

        }

        private void click_b38(object sender, RoutedEventArgs e)
        {
            if (b38.Opacity == 1)
                return;
            b38.Opacity = 1;
            if (is_tile_complete(5))
            {
                if (curr_turn == 1)
                {
                    slogo_5.Opacity = 1;
                    stile_5.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_5.Opacity = 1;
                    btile_5.Opacity = 1;
                    bat_score++;
                }
                update_scores();
            }
            else { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();

        }

        private void click_b39(object sender, RoutedEventArgs e)
        {
            if (b39.Opacity == 1)
                return;
            b39.Opacity = 1;
            
            if (is_tile_complete(5))
            {
                if (curr_turn == 1)
                {
                    slogo_5.Opacity = 1;
                    stile_5.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_5.Opacity = 1;
                    btile_5.Opacity = 1;
                    bat_score++;
                }
                update_scores();
            }
            else { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();

        }

        private void click_b40(object sender, RoutedEventArgs e)
        {
            if (b40.Opacity == 1)
                return;
            b40.Opacity = 1;
            
            if (is_tile_complete(5))
            {
                if (curr_turn == 1)
                {
                    slogo_5.Opacity = 1;
                    stile_5.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_5.Opacity = 1;
                    btile_5.Opacity = 1;
                    bat_score++;
                }
                update_scores();
            }
            else { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();

        }

        private void click_b41(object sender, RoutedEventArgs e)
        {
            if (b41.Opacity == 1)
                return;
            b41.Opacity = 1;

            bool pent_made = false;

            if (is_tile_complete(5))
            {
                if (curr_turn == 1)
                {
                    slogo_5.Opacity = 1;
                    stile_5.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_5.Opacity = 1;
                    btile_5.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (is_tile_complete(7))
            {
                if (curr_turn == 1)
                {
                    slogo_7.Opacity = 1;
                    stile_7.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_7.Opacity = 1;
                    btile_7.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();


        }

        private void click_b42(object sender, RoutedEventArgs e)
        {
            if (b42.Opacity == 1)
                return;
            b42.Opacity = 1;

            if (is_tile_complete(7))
            {
                if (curr_turn == 1)
                {
                    slogo_7.Opacity = 1;
                    stile_7.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_7.Opacity = 1;
                    btile_7.Opacity = 1;
                    bat_score++;
                }
                update_scores();
            }
            else { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();

        }

        private void click_b43(object sender, RoutedEventArgs e)
        {
            if (b43.Opacity == 1)
                return;
            b43.Opacity = 1;

            bool pent_made = false;

            if (is_tile_complete(7))
            {
                if (curr_turn == 1)
                {
                    slogo_7.Opacity = 1;
                    stile_7.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_7.Opacity = 1;
                    btile_7.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (is_tile_complete(8))
            {
                if (curr_turn == 1)
                {
                    slogo_8.Opacity = 1;
                    stile_8.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_8.Opacity = 1;
                    btile_8.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();

        }

        private void click_b44(object sender, RoutedEventArgs e)
        {
            if (b44.Opacity == 1)
                return;
            b44.Opacity = 1;
            if (is_tile_complete(8))
            {
                if (curr_turn == 1)
                {
                    slogo_8.Opacity = 1;
                    stile_8.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_8.Opacity = 1;
                    btile_8.Opacity = 1;
                    bat_score++;
                }
                update_scores();
            }
            else { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();


        }

        private void click_b45(object sender, RoutedEventArgs e)
        {
            if (b45.Opacity == 1)
                return;
            b45.Opacity = 1;
            if (is_tile_complete(8))
            {
                if (curr_turn == 1)
                {
                    slogo_8.Opacity = 1;
                    stile_8.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_8.Opacity = 1;
                    btile_8.Opacity = 1;
                    bat_score++;
                }
                update_scores();
            }
            else { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();

        }

        private void click_b46(object sender, RoutedEventArgs e)
        {
            if (b46.Opacity == 1)
                return;
            b46.Opacity = 1;
            bool pent_made = false;

            if (is_tile_complete(8))
            {
                if (curr_turn == 1)
                {
                    slogo_8.Opacity = 1;
                    stile_8.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_8.Opacity = 1;
                    btile_8.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (is_tile_complete(22))
            {
                if (curr_turn == 1)
                {
                    slogo_22.Opacity = 1;
                    stile_22.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_22.Opacity = 1;
                    btile_22.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();

        }

        private void click_b47(object sender, RoutedEventArgs e)
        {
            if (b47.Opacity == 1)
                return;
            b47.Opacity = 1;
            bool pent_made = false;

            if (is_tile_complete(21))
            {
                if (curr_turn == 1)
                {
                    slogo_21.Opacity = 1;
                    stile_21.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_21.Opacity = 1;
                    btile_21.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (is_tile_complete(8))
            {
                if (curr_turn == 1)
                {
                    slogo_8.Opacity = 1;
                    stile_8.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_8.Opacity = 1;
                    btile_8.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();

        }

        private void click_b48(object sender, RoutedEventArgs e)
        {
            if (b48.Opacity == 1)
                return;
            b48.Opacity = 1;
            if (is_tile_complete(22))
            {
                if (curr_turn == 1)
                {
                    slogo_22.Opacity = 1;
                    stile_22.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_22.Opacity = 1;
                    btile_22.Opacity = 1;
                    bat_score++;
                }
                update_scores();
            }
            else { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();


        }

        private void click_b49(object sender, RoutedEventArgs e)
        {
            if (b49.Opacity == 1)
                return;
            b49.Opacity = 1;

            bool pent_made = false;

            if (is_tile_complete(21))
            {
                if (curr_turn == 1)
                {
                    slogo_21.Opacity = 1;
                    stile_21.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_21.Opacity = 1;
                    btile_21.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (is_tile_complete(22))
            {
                if (curr_turn == 1)
                {
                    slogo_22.Opacity = 1;
                    stile_22.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_22.Opacity = 1;
                    btile_22.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();

        }


         private void click_b015(object sender, RoutedEventArgs e)
         {
                     if (b015.Opacity == 1)
                 return;
             b015.Opacity = 1;

             if (is_tile_complete(14))
             {
                 if (curr_turn == 1)
                 {
                     slogo_14.Opacity = 1;
                     stile_14.Opacity = 1;
                     super_score++;
                 }
                 if (curr_turn == 2)
                 {
                     blogo_14.Opacity = 1;
                     btile_14.Opacity = 1;
                     bat_score++;
                 }
                 update_scores();
             }
             else { curr_turn = 3 - curr_turn; }
             Curr_Player_anim();
         }

         private void click_b013(object sender, RoutedEventArgs e)
         {
             if (b013.Opacity == 1)
                 return;
             b013.Opacity = 1;

             bool pent_made = false;

             if (is_tile_complete(14))
             {
                 if (curr_turn == 1)
                 {
                     slogo_14.Opacity = 1;
                     stile_14.Opacity = 1;
                     super_score++;
                 }
                 if (curr_turn == 2)
                 {
                     blogo_14.Opacity = 1;
                     btile_14.Opacity = 1;
                     bat_score++;
                 }
                 pent_made = true;
                 update_scores();
             }
             if (is_tile_complete(15))
             {
                 if (curr_turn == 1)
                 {
                     slogo_15.Opacity = 1;
                     stile_15.Opacity = 1;
                     super_score++;
                 }
                 if (curr_turn == 2)
                 {
                     blogo_15.Opacity = 1;
                     btile_15.Opacity = 1;
                     bat_score++;
                 }
                 pent_made = true;
                 update_scores();
             }
             if (!pent_made) { curr_turn = 3 - curr_turn; }
             Curr_Player_anim();
         }

         private void click_b012(object sender, RoutedEventArgs e)
         {
             if (b012.Opacity == 1)
                 return;
             b012.Opacity = 1;

             if (is_tile_complete(15))
             {
                 if (curr_turn == 1)
                 {
                     slogo_15.Opacity = 1;
                     stile_15.Opacity = 1;
                     super_score++;
                 }
                 if (curr_turn == 2)
                 {
                     blogo_15.Opacity = 1;
                     btile_15.Opacity = 1;
                     bat_score++;
                 }
                 update_scores();
             }
             else { curr_turn = 3 - curr_turn; }
             Curr_Player_anim();
         }

         private void click_b011(object sender, RoutedEventArgs e)
         {
             if (b011.Opacity == 1)
                 return;
             b011.Opacity = 1;

             if (is_tile_complete(15))
             {
                 if (curr_turn == 1)
                 {
                     slogo_15.Opacity = 1;
                     stile_15.Opacity = 1;
                     super_score++;
                 }
                 if (curr_turn == 2)
                 {
                     blogo_15.Opacity = 1;
                     btile_15.Opacity = 1;
                     bat_score++;
                 }
                 update_scores();
             }
             else { curr_turn = 3 - curr_turn; }
             Curr_Player_anim();
         }
		

         
        private void click_b01(object sender, RoutedEventArgs e)
        {
            if (b01.Opacity == 1)
                return;
            b01.Opacity = 1;
            if (is_tile_complete(30))
            {
                if (curr_turn == 1)
                {
                    slogo_30.Opacity = 1;
                    stile_30.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_30.Opacity = 1;
                    btile_30.Opacity = 1;
                    bat_score++;
                }
                update_scores();
            }
            else { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }

        private void click_b03(object sender, RoutedEventArgs e)
        {
            if (b03.Opacity == 1)
                return;
            b03.Opacity = 1;
            if (is_tile_complete(30))
            {
                if (curr_turn == 1)
                {
                    slogo_30.Opacity = 1;
                    stile_30.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_30.Opacity = 1;
                    btile_30.Opacity = 1;
                    bat_score++;
                }
                update_scores();
            }
            else { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();

        }

        private void click_b04(object sender, RoutedEventArgs e)
        {
            if (b04.Opacity == 1)
                return;
            b04.Opacity = 1;
            bool pent_made = false;

            if (is_tile_complete(16))
            {
                if (curr_turn == 1)
                {
                    slogo_16.Opacity = 1;
                    stile_16.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_16.Opacity = 1;
                    btile_16.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (is_tile_complete(30))
            {
                if (curr_turn == 1)
                {
                    slogo_30.Opacity = 1;
                    stile_30.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_30.Opacity = 1;
                    btile_30.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();

        }

        private void click_b05(object sender, RoutedEventArgs e)
        {
            if (b05.Opacity == 1)
                return;
            b05.Opacity = 1;
            bool pent_made = false;

            if (is_tile_complete(30))
            {
                if (curr_turn == 1)
                {
                    slogo_30.Opacity = 1;
                    stile_30.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_30.Opacity = 1;
                    btile_30.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (is_tile_complete(29))
            {
                if (curr_turn == 1)
                {
                    slogo_29.Opacity = 1;
                    stile_29.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_29.Opacity = 1;
                    btile_29.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }

        private void click_b06(object sender, RoutedEventArgs e)
        {
            if (b06.Opacity == 1)
                return;
            b06.Opacity = 1;
            if (is_tile_complete(30))
            {
                if (curr_turn == 1)
                {
                    slogo_30.Opacity = 1;
                    stile_30.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_30.Opacity = 1;
                    btile_30.Opacity = 1;
                    bat_score++;
                }
                update_scores();
            }
            else { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();

        }

        private void click_b07(object sender, RoutedEventArgs e)
        {
            if (b07.Opacity == 1)
                return;
            b07.Opacity = 1;
            if (is_tile_complete(16))
            {
                if (curr_turn == 1)
                {
                    slogo_16.Opacity = 1;
                    stile_16.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_16.Opacity = 1;
                    btile_16.Opacity = 1;
                    bat_score++;
                }
                update_scores();
            }
            else { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }

        private void click_b08(object sender, RoutedEventArgs e)
        {
            if (b08.Opacity == 1)
                return;
            b08.Opacity = 1;
            bool pent_made = false;

            if (is_tile_complete(15))
            {
                if (curr_turn == 1)
                {
                    slogo_15.Opacity = 1;
                    stile_15.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_15.Opacity = 1;
                    btile_15.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (is_tile_complete(16))
            {
                if (curr_turn == 1)
                {
                    slogo_16.Opacity = 1;
                    stile_16.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_16.Opacity = 1;
                    btile_16.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }

        private void click_b09(object sender, RoutedEventArgs e)
        {
            if (b09.Opacity == 1)
                return;
            b09.Opacity = 1;
            bool pent_made = false;

            if (is_tile_complete(17))
            {
                if (curr_turn == 1)
                {
                    slogo_17.Opacity = 1;
                    stile_17.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_17.Opacity = 1;
                    btile_17.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (is_tile_complete(16))
            {
                if (curr_turn == 1)
                {
                    slogo_16.Opacity = 1;
                    stile_16.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_16.Opacity = 1;
                    btile_16.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }

        private void click_b010(object sender, RoutedEventArgs e)
        {
            if (b010.Opacity == 1)
                return;
            b010.Opacity = 1;
            bool pent_made = false;

            if (is_tile_complete(16))
            {
                if (curr_turn == 1)
                {
                    slogo_16.Opacity = 1;
                    stile_16.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_16.Opacity = 1;
                    btile_16.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (is_tile_complete(29))
            {
                if (curr_turn == 1)
                {
                    slogo_29.Opacity = 1;
                    stile_29.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_29.Opacity = 1;
                    btile_29.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();

        }

        
       
      

        private void click_b014(object sender, RoutedEventArgs e)
        {
            if (b014.Opacity == 1)
                return;
            b014.Opacity = 1;

            bool pent_made = false;

            if (is_tile_complete(12))
            {
                if (curr_turn == 1)
                {
                    slogo_12.Opacity = 1;
                    stile_12.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_12.Opacity = 1;
                    btile_12.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (is_tile_complete(15))
            {
                if (curr_turn == 1)
                {
                    slogo_15.Opacity = 1;
                    stile_15.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_15.Opacity = 1;
                    btile_15.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }

      



        private void click_b017(object sender, RoutedEventArgs e)
        {
            if (b017.Opacity == 1)
                return;
            b017.Opacity = 1;
            bool pent_made = false;

            if (is_tile_complete(12))
            {
                if (curr_turn == 1)
                {
                    slogo_12.Opacity = 1;
                    stile_12.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_12.Opacity = 1;
                    btile_12.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (is_tile_complete(17))
            {
                if (curr_turn == 1)
                {
                    slogo_17.Opacity = 1;
                    stile_17.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_17.Opacity = 1;
                    btile_17.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();

        }


        private void click_b019(object sender, RoutedEventArgs e)
        {
            if (b019.Opacity == 1)
                return;
            b019.Opacity = 1;
            bool pent_made = false;

            if (is_tile_complete(17))
            {
                if (curr_turn == 1)
                {
                    slogo_17.Opacity = 1;
                    stile_17.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_17.Opacity = 1;
                    btile_17.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (is_tile_complete(18))
            {
                if (curr_turn == 1)
                {
                    slogo_18.Opacity = 1;
                    stile_18.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_18.Opacity = 1;
                    btile_18.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();

        }

        private void click_b020(object sender, RoutedEventArgs e)
        {
            if (b020.Opacity == 1)
                return;
            b020.Opacity = 1;
            bool pent_made = false;

            if (is_tile_complete(17))
            {
                if (curr_turn == 1)
                {
                    slogo_17.Opacity = 1;
                    stile_17.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_17.Opacity = 1;
                    btile_17.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (is_tile_complete(29))
            {
                if (curr_turn == 1)
                {
                    slogo_29.Opacity = 1;
                    stile_29.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_29.Opacity = 1;
                    btile_29.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }

        private void click_b021(object sender, RoutedEventArgs e)
        {
            if (b021.Opacity == 1)
                return;
            b021.Opacity = 1;
            bool pent_made = false;

            if (is_tile_complete(18))
            {
                if (curr_turn == 1)
                {
                    slogo_18.Opacity = 1;
                    stile_18.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_18.Opacity = 1;
                    btile_18.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (is_tile_complete(27))
            {
                if (curr_turn == 1)
                {
                    slogo_27.Opacity = 1;
                    stile_27.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_27.Opacity = 1;
                    btile_27.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }

        private void click_b022(object sender, RoutedEventArgs e)
        {
            if (b022.Opacity == 1)
                return;
            b022.Opacity = 1;
            bool pent_made = false;

            if (is_tile_complete(29))
            {
                if (curr_turn == 1)
                {
                    slogo_29.Opacity = 1;
                    stile_29.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_29.Opacity = 1;
                    btile_29.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (is_tile_complete(27))
            {
                if (curr_turn == 1)
                {
                    slogo_27.Opacity = 1;
                    stile_27.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_27.Opacity = 1;
                    btile_27.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();

        }

        private void click_b023(object sender, RoutedEventArgs e)
        {
            if (b023.Opacity == 1)
                return;
            b023.Opacity = 1;
            bool pent_made = false;

            if (is_tile_complete(28))
            {
                if (curr_turn == 1)
                {
                    slogo_28.Opacity = 1;
                    stile_28.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_28.Opacity = 1;
                    btile_28.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (is_tile_complete(27))
            {
                if (curr_turn == 1)
                {
                    slogo_27.Opacity = 1;
                    stile_27.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_27.Opacity = 1;
                    btile_27.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }

        private void click_b024(object sender, RoutedEventArgs e)
        {
            if (b024.Opacity == 1)
                return;
            b024.Opacity = 1;
            bool pent_made = false;

            if (is_tile_complete(26))
            {
                if (curr_turn == 1)
                {
                    slogo_26.Opacity = 1;
                    stile_26.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_26.Opacity = 1;
                    btile_26.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (is_tile_complete(27))
            {
                if (curr_turn == 1)
                {
                    slogo_27.Opacity = 1;
                    stile_27.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_27.Opacity = 1;
                    btile_27.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }

        private void click_b025(object sender, RoutedEventArgs e)
        {
            if (b025.Opacity == 1)
                return;
            b025.Opacity = 1;
            bool pent_made = false;

            if (is_tile_complete(19))
            {
                if (curr_turn == 1)
                {
                    slogo_19.Opacity = 1;
                    stile_19.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_19.Opacity = 1;
                    btile_19.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (is_tile_complete(27))
            {
                if (curr_turn == 1)
                {
                    slogo_27.Opacity = 1;
                    stile_27.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_27.Opacity = 1;
                    btile_27.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }



        private void click_b027(object sender, RoutedEventArgs e)
        {
            if (b027.Opacity == 1)
                return;
            b027.Opacity = 1;
            bool pent_made = false;

            if (is_tile_complete(19))
            {
                if (curr_turn == 1)
                {
                    slogo_19.Opacity = 1;
                    stile_19.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_19.Opacity = 1;
                    btile_19.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (is_tile_complete(20))
            {
                if (curr_turn == 1)
                {
                    slogo_20.Opacity = 1;
                    stile_20.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_20.Opacity = 1;
                    btile_20.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }



        private void click_b029(object sender, RoutedEventArgs e)
        {
            if (b029.Opacity == 1)
                return;
            b029.Opacity = 1;

            bool pent_made = false;

            if (is_tile_complete(21))
            {
                if (curr_turn == 1)
                {
                    slogo_21.Opacity = 1;
                    stile_21.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_21.Opacity = 1;
                    btile_21.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (is_tile_complete(20))
            {
                if (curr_turn == 1)
                {
                    slogo_20.Opacity = 1;
                    stile_20.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_20.Opacity = 1;
                    btile_20.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }

        private void click_b030(object sender, RoutedEventArgs e)
        {
            if (b030.Opacity == 1)
                return;
            b030.Opacity = 1;
            bool pent_made = false;

            if (is_tile_complete(20))
            {
                if (curr_turn == 1)
                {
                    slogo_20.Opacity = 1;
                    stile_20.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_20.Opacity = 1;
                    btile_20.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (is_tile_complete(24))
            {
                if (curr_turn == 1)
                {
                    slogo_24.Opacity = 1;
                    stile_24.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_24.Opacity = 1;
                    btile_24.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }

        private void click_b031(object sender, RoutedEventArgs e)
        {
            if (b031.Opacity == 1)
                return;
            b031.Opacity = 1;
            bool pent_made = false;

            if (is_tile_complete(20))
            {
                if (curr_turn == 1)
                {
                    slogo_20.Opacity = 1;
                    stile_20.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_20.Opacity = 1;
                    btile_20.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (is_tile_complete(26))
            {
                if (curr_turn == 1)
                {
                    slogo_26.Opacity = 1;
                    stile_26.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_26.Opacity = 1;
                    btile_26.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }

        private void click_b032(object sender, RoutedEventArgs e)
        {
            if (b032.Opacity == 1)
                return;
            b032.Opacity = 1;
            bool pent_made = false;

            if (is_tile_complete(24))
            {
                if (curr_turn == 1)
                {
                    slogo_24.Opacity = 1;
                    stile_24.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_24.Opacity = 1;
                    btile_24.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (is_tile_complete(26))
            {
                if (curr_turn == 1)
                {
                    slogo_26.Opacity = 1;
                    stile_26.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_26.Opacity = 1;
                    btile_26.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }

        private void click_b033(object sender, RoutedEventArgs e)
        {
            if (b033.Opacity == 1)
                return;
            b033.Opacity = 1;
            bool pent_made = false;

            if (is_tile_complete(25))
            {
                if (curr_turn == 1)
                {
                    slogo_25.Opacity = 1;
                    stile_25.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_25.Opacity = 1;
                    btile_25.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (is_tile_complete(26))
            {
                if (curr_turn == 1)
                {
                    slogo_26.Opacity = 1;
                    stile_26.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_26.Opacity = 1;
                    btile_26.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }

        private void click_b034(object sender, RoutedEventArgs e)
        {
            if (b034.Opacity == 1)
                return;
            b034.Opacity = 1;
            bool pent_made = false;

            if (is_tile_complete(28))
            {
                if (curr_turn == 1)
                {
                    slogo_28.Opacity = 1;
                    stile_28.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_28.Opacity = 1;
                    btile_28.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (is_tile_complete(26))
            {
                if (curr_turn == 1)
                {
                    slogo_26.Opacity = 1;
                    stile_26.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_26.Opacity = 1;
                    btile_26.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }

        private void click_b035(object sender, RoutedEventArgs e)
        {
            if (b035.Opacity == 1)
                return;
            b035.Opacity = 1;
            bool pent_made = false;

            if (is_tile_complete(28))
            {
                if (curr_turn == 1)
                {
                    slogo_28.Opacity = 1;
                    stile_28.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_28.Opacity = 1;
                    btile_28.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (is_tile_complete(29))
            {
                if (curr_turn == 1)
                {
                    slogo_29.Opacity = 1;
                    stile_29.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_29.Opacity = 1;
                    btile_29.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }

        private void click_b036(object sender, RoutedEventArgs e)
        {
            if (b036.Opacity == 1)
                return;
            b036.Opacity = 1;

            if (is_tile_complete(28))
            {
                if (curr_turn == 1)
                {
                    slogo_28.Opacity = 1;
                    stile_28.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_28.Opacity = 1;
                    btile_28.Opacity = 1;
                    bat_score++;
                }
                update_scores();
            }
            else { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();

        }

        private void click_b037(object sender, RoutedEventArgs e)
        {
            if (b037.Opacity == 1)
                return;
            b037.Opacity = 1;

            if (is_tile_complete(28))
            {
                if (curr_turn == 1)
                {
                    slogo_28.Opacity = 1;
                    stile_28.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_28.Opacity = 1;
                    btile_28.Opacity = 1;
                    bat_score++;
                }
                update_scores();
            }
            else { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }

        private void click_b038(object sender, RoutedEventArgs e)
        {
            if (b038.Opacity == 1)
                return;
            b038.Opacity = 1;

            if (is_tile_complete(25))
            {
                if (curr_turn == 1)
                {
                    slogo_25.Opacity = 1;
                    stile_25.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_25.Opacity = 1;
                    btile_25.Opacity = 1;
                    bat_score++;
                }
                update_scores();
            }
            else { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }

        private void click_b039(object sender, RoutedEventArgs e)
        {
            if (b039.Opacity == 1)
                return;
            b039.Opacity = 1;
            if (is_tile_complete(25))
            {
                if (curr_turn == 1)
                {
                    slogo_25.Opacity = 1;
                    stile_25.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_25.Opacity = 1;
                    btile_25.Opacity = 1;
                    bat_score++;
                }
                update_scores();
            }
            else { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }

        private void click_b040(object sender, RoutedEventArgs e)
        {
            if (b040.Opacity == 1)
                return;
            b040.Opacity = 1;

            if (is_tile_complete(25))
            {
                if (curr_turn == 1)
                {
                    slogo_25.Opacity = 1;
                    stile_25.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_25.Opacity = 1;
                    btile_25.Opacity = 1;
                    bat_score++;
                }
                update_scores();
            }
            else { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }

        private void click_b041(object sender, RoutedEventArgs e)
        {
            if (b041.Opacity == 1)
                return;
            b041.Opacity = 1;

            bool pent_made = false;

            if (is_tile_complete(24))
            {
                if (curr_turn == 1)
                {
                    slogo_24.Opacity = 1;
                    stile_24.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_24.Opacity = 1;
                    btile_24.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (is_tile_complete(25))
            {
                if (curr_turn == 1)
                {
                    slogo_25.Opacity = 1;
                    stile_25.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_25.Opacity = 1;
                    btile_25.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }

        private void click_b042(object sender, RoutedEventArgs e)
        {
            if (b042.Opacity == 1)
                return;
            b042.Opacity = 1;

            if (is_tile_complete(24))
            {
                if (curr_turn == 1)
                {
                    slogo_24.Opacity = 1;
                    stile_24.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_24.Opacity = 1;
                    btile_24.Opacity = 1;
                    bat_score++;
                }
                update_scores();
            }
            else { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();

        }

        private void click_b043(object sender, RoutedEventArgs e)
        {
            if (b043.Opacity == 1)
                return;
            b043.Opacity = 1;

            bool pent_made = false;

            if (is_tile_complete(23))
            {
                if (curr_turn == 1)
                {
                    slogo_23.Opacity = 1;
                    stile_23.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_23.Opacity = 1;
                    btile_23.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (is_tile_complete(24))
            {
                if (curr_turn == 1)
                {
                    slogo_24.Opacity = 1;
                    stile_24.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_24.Opacity = 1;
                    btile_24.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }

        private void click_b044(object sender, RoutedEventArgs e)
        {
            if (b044.Opacity == 1)
                return;
            b044.Opacity = 1;
            if (is_tile_complete(23))
            {
                if (curr_turn == 1)
                {
                    slogo_23.Opacity = 1;
                    stile_23.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_23.Opacity = 1;
                    btile_23.Opacity = 1;
                    bat_score++;
                }
                update_scores();
            }
            else { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }

        private void click_b045(object sender, RoutedEventArgs e)
        {
            if (b045.Opacity == 1)
                return;
            b045.Opacity = 1;
            if (is_tile_complete(23))
            {
                if (curr_turn == 1)
                {
                    slogo_23.Opacity = 1;
                    stile_23.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_23.Opacity = 1;
                    btile_23.Opacity = 1;
                    bat_score++;
                }
                update_scores();
            }
            else { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }

        private void click_b046(object sender, RoutedEventArgs e)
        {
            if (b046.Opacity == 1)
                return;
            b046.Opacity = 1;
            bool pent_made = false;

            if (is_tile_complete(22))
            {
                if (curr_turn == 1)
                {
                    slogo_22.Opacity = 1;
                    stile_22.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_22.Opacity = 1;
                    btile_22.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (is_tile_complete(23))
            {
                if (curr_turn == 1)
                {
                    slogo_23.Opacity = 1;
                    stile_23.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_23.Opacity = 1;
                    btile_23.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }

        private void click_b047(object sender, RoutedEventArgs e)
        {
            if (b047.Opacity == 1)
                return;
            b047.Opacity = 1;
            bool pent_made = false;

            if (is_tile_complete(21))
            {
                if (curr_turn == 1)
                {
                    slogo_21.Opacity = 1;
                    stile_21.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_21.Opacity = 1;
                    btile_21.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (is_tile_complete(23))
            {
                if (curr_turn == 1)
                {
                    slogo_23.Opacity = 1;
                    stile_23.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_23.Opacity = 1;
                    btile_23.Opacity = 1;
                    bat_score++;
                }
                pent_made = true;
                update_scores();
            }
            if (!pent_made) { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }

        private void click_b048(object sender, RoutedEventArgs e)
        {
            if (b048.Opacity == 1)
                return;
            b048.Opacity = 1;

            if (is_tile_complete(22))
            {
                if (curr_turn == 1)
                {
                    slogo_22.Opacity = 1;
                    stile_22.Opacity = 1;
                    super_score++;
                }
                if (curr_turn == 2)
                {
                    blogo_22.Opacity = 1;
                    btile_22.Opacity = 1;
                    bat_score++;
                }
                update_scores();
            }
            else { curr_turn = 3 - curr_turn; }
            Curr_Player_anim();
        }

        private void enter_sname(object sender, RoutedEventArgs e)
        {
            string sname = Player1_Name.Text;
            s_name.Content = sname;
            //Player1_button.Flyout.Hide();
        }

        private void enter_bname(object sender, RoutedEventArgs e)
        {
            string sname = Player2_Name.Text;
            b_name.Content = sname;
            //Player2_button.Flyout.Hide();
        }

       
        
    }
}