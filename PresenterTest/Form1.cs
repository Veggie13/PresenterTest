using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PresenterTest
{
    public partial class Form1 : Form
    {
        private SelectableBindingList<ITestPresenterItem> _items = new SelectableBindingList<ITestPresenterItem>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _items.Add(new TestPresenterItem(new TestObject()
            {
                Name = "First",
                Desc = "The first one",
                Val = 6,
                Type = TestObject.eType.T1
            })
            {
                Selected = true
            });
            _items.Add(new TestPresenterItem(new TestObject()
            {
                Name = "Second",
                Desc = "The next one",
                Val = 6,
                Type = TestObject.eType.T3
            })
            {
                Selected = true
            });
            _items.Add(new TestPresenterItem(new TestObject()
            {
                Name = "Third",
                Desc = "The best one",
                Val = 6,
                Type = TestObject.eType.T2
            })
            {
                Selected = false
            });
            _items.Add(new TestPresenterItem(new TestObject()
            {
                Name = "Fourth",
                Desc = "The favourite one",
                Val = 6,
                Type = TestObject.eType.T2
            })
            {
                Selected = false
            });
            _items.Add(new TestPresenterItem(new TestObject()
            {
                Name = "Fifth",
                Desc = "The last one",
                Val = 6,
                Type = TestObject.eType.T1
            })
            {
                Selected = true
            });

            dataGridView1.DataSource = _items;
            dataGridView2.DataSource = _items.UnselectedItems;
            dataGridView3.DataSource = _items.SelectedItems;

            foreach (var row in dataGridView1.Rows.Cast<DataGridViewRow>())
            {
                row.Selected = ((ISelectable)row.DataBoundItem).Selected;
            }

            dataGridView1.SelectionChanged += new EventHandler(dataGridView1_SelectionChanged);
            dataGridView2.CellDoubleClick += new DataGridViewCellEventHandler(dataGridView2_CellDoubleClick);
            dataGridView3.CellDoubleClick += new DataGridViewCellEventHandler(dataGridView3_CellDoubleClick);

            _items.ListChanged += new ListChangedEventHandler(_items_ListChanged);
        }

        void _items_ListChanged(object sender, ListChangedEventArgs e)
        {
            foreach (var row in dataGridView1.Rows.Cast<DataGridViewRow>())
            {
                row.Selected = ((ISelectable)row.DataBoundItem).Selected;
            }
        }

        void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ((ISelectable)dataGridView3.Rows[e.RowIndex].DataBoundItem).Selected = false;
        }

        void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ((ISelectable)dataGridView2.Rows[e.RowIndex].DataBoundItem).Selected = true;
        }

        void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            foreach (var row in dataGridView1.Rows.Cast<DataGridViewRow>())
            {
                ((ISelectable)row.DataBoundItem).Selected = row.Selected;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _items[2] = (new TestPresenterItem(new TestObject()
            {
                Name = "Sixth",
                Desc = "Bonus",
                Val = 12,
                Type = TestObject.eType.T3
            })
            {
                Selected = true
            });
        }
    }
}
