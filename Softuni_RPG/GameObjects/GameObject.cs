using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Softuni_RPG.GameObjects
{
    public abstract class GameObject
    {
        private const int minLenghtName = 3;
        private const int maxLenghtName = 10;

        private string name;
        private Image image;
        private string imagePath;

        protected GameObject(string name, string imagePath)
        {
            this.Name = name;
            this.ImagePath(imagePath);
        }
        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be empty.");
                }
                if (value.Trim().Length < minLenghtName || value.Trim().Length > maxLenghtName)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Name should be more than {0} and {1}", minLenghtName, maxLenghtName));
                }
                this.name = value;
            }
        }

        public Image Image { get; private set; }
        protected void ImagePath(string imagePath)
        {
            {
                if (string.IsNullOrEmpty(imagePath))
                {
                    throw new ArgumentNullException("imagePath");
                }
                this.imagePath = imagePath;
                this.Image = Image.FromFile(this.imagePath);
            }
        }

    }
}
