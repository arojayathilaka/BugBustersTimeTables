using BBTG.Entities.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Time_Table_Generator.ViewModel;

namespace Time_Table_Generator.View
{
    /// <summary>
    /// Interaction logic for TagView.xaml
    /// </summary>
    public partial class TagView : Page
    {
        TagViewModel _tagViewModel;
        TagEntity tag;
        //int tagId;
        bool updateMode = false;
        List<TagEntity> tags;
        List<string> tagNames = new List<string>();

        public TagView()
        {
            InitializeComponent();
        }

        private void Tag_Page_Loaded(object sender, RoutedEventArgs e)
        {
            _tagViewModel = new TagViewModel();

            tags = _tagViewModel.LoadTagData();
            tag_data_grid.ItemsSource = tags;

            foreach (TagEntity s in tags)
            {
                tagNames.Add(s.TagName);
            }

            add_btn_.IsEnabled = false;
            update_btn_.IsEnabled = false;
            delete_btn_.IsEnabled = false;
        }

        private void add_btn__Click(object sender, RoutedEventArgs e)
        {
            try
            {
                tag = CreateTagEntity();
                tagNames.Add(tag.TagName);
                _tagViewModel.SaveTagData(tag);
                tags = _tagViewModel.LoadTagData();
                tag_data_grid.ItemsSource = tags;
                ClearAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void update_btn__Click(object sender, RoutedEventArgs e)
        {
            try
            {
                tagNames.Remove(tag.TagName);
                tag = CreateTagEntity();
                tagNames.Add(tag.TagName);
                _tagViewModel.UpdateTagData(tag);
                tag_data_grid.ItemsSource = _tagViewModel.LoadTagData();
                ClearAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void delete_btn__Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete?", "BBTG", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    tagNames.Remove(tag.TagName);
                    int TagId = tag.TagId;
                    _tagViewModel.DeleteTagData(TagId);
                    tags = _tagViewModel.LoadTagData();
                    tag_data_grid.ItemsSource = tags;
                    ClearAll();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ClearAll()
        {
            tagName_txtbx.Text = "";
            updateMode = false;
            add_btn_.IsEnabled = false;
            update_btn_.IsEnabled = false;
            delete_btn_.IsEnabled = false;
        }

        private void tag_data_grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            updateMode = true;
            delete_btn_.IsEnabled = true;

            DataGrid dataGrid = (DataGrid)sender;
            tag = dataGrid.SelectedItem as TagEntity;

            if (tag != null)
            {
                tagName_txtbx.Text = tag.TagName;
                }
        }

        private void clear_all_btn__Click(object sender, RoutedEventArgs e)
        {
            ClearAll();
        }

        private TagEntity CreateTagEntity()
        {
            int TagId;
            if (updateMode)
            {
                TagId = tag.TagId;
            }
            else
            {
                TagId = tags.Last().TagId + 1;
            }

            string TagName = tagName_txtbx.Text;

            tag = new TagEntity(TagId, TagName);
            return tag;
        }

        private void CheckValidations()
        {
            //if (
            //    //code_txtbx.Text != "Eg: IT1050" &&
            //    //!tagNames.Contains(name_txtbx.Text) &&
            //    //!tagCodes.Contains(code_txtbx.Text) &&
            //    //!String.IsNullOrEmpty(year_combobx_val) &&
            //    //!String.IsNullOrEmpty(sem_combobx_val) &&
            //    //!String.IsNullOrEmpty(lec_combobx_val) &&
            //    //!String.IsNullOrEmpty(tute_combobx_val) &&
            //    //!String.IsNullOrEmpty(lab_combobx_val) &&
            //    //!String.IsNullOrEmpty(eval_combobx_val) &&
            //    //!String.IsNullOrEmpty(name_txtbx.Text) &&
            //    //!String.IsNullOrEmpty(code_txtbx.Text) 
            //    )
            //{
            //    if (updateMode) update_btn_.IsEnabled = true;
            //    else add_btn_.IsEnabled = true;
            //}
            //else
            //{
            //    if (updateMode) update_btn_.IsEnabled = false;
            //    else add_btn_.IsEnabled = false;
            //}


            if (
                updateMode &&
                !String.IsNullOrEmpty(tagName_txtbx.Text)
                )
            {
                update_btn_.IsEnabled = true;
            }
            else
            {
                update_btn_.IsEnabled = false;
            }

            if (
                !updateMode &&
                !String.IsNullOrEmpty(tagName_txtbx.Text)
               )
            {
                add_btn_.IsEnabled = true;
            }
            else
            {
                add_btn_.IsEnabled = false;
            }
        }


        private void tagName_txtbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckValidations();
        }
    }
}
