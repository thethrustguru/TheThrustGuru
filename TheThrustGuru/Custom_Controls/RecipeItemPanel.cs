using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheThrustGuru.Custom_Controls
{
    class RecipeItemPanel : Panel
    {
        //public string itemImageurl { get; set; }
        //public string itemName { get; set; }
        //public string itemPrice { get; set; }

        private Label recipePriceLabel = new Label(),recipeNameLabel = new Label();        
        //private Button button;

        public RecipeItemPanel(string itemName, string id, Button button)
        {              
            //this.button = button;             

            button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            button.FlatAppearance.BorderSize = 0;
            button.FlatStyle = FlatStyle.Flat;
            button.Location = new System.Drawing.Point(3, 3);
            button.Name = itemName;
            button.Tag = id;
            button.Size = new System.Drawing.Size(150, 76);           
            button.UseVisualStyleBackColor = false;           
            // 
            // recipeNameLabel
            // 
            this.recipeNameLabel.Location = new System.Drawing.Point(7, 82);
            this.recipeNameLabel.Name = "recipeNameLabel" + id;
            this.recipeNameLabel.Size = new System.Drawing.Size(93, 13);           
            this.recipeNameLabel.Text = itemName;
            this.recipeNameLabel.AutoSize = true;
            // 
            // recipePriceLabel
            // 
            //this.recipePriceLabel.Location = new System.Drawing.Point(105, 85);
            //this.recipePriceLabel.Name = "recipePriceLabel" + index.ToString();
            //this.recipePriceLabel.Size = new System.Drawing.Size(43, 13);           
            //this.recipePriceLabel.Text = itemPrice;

            this.BackColor = System.Drawing.Color.White;
            //this.Controls.Add(this.recipePriceLabel);
            this.Controls.Add(this.recipeNameLabel);
            this.Controls.Add(button);
            this.Name = "recipePanel" + id;
            this.Size = new System.Drawing.Size(156, 105);

        }


    }
}
