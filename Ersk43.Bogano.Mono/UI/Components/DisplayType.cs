using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ersk43.Bogano.Mono.UI.Components
{
    public enum DisplayTypeEnum
    {
        FullWidth,
        Inline
    }
    internal class DisplayType
    {
       public DisplayTypeEnum displayType = DisplayTypeEnum.FullWidth;
    }

    public enum OrientationEnum
    {
        Row,
        Column
    }
    internal class DisplayFlex
    {
        public OrientationEnum Orientation { get; set; }
        public int Gap { get; set; }

        public DisplayFlex(OrientationEnum orientation = OrientationEnum.Column, int gap = 0)
        {
            Orientation = orientation;
            Gap = gap;
        }
        public DisplayFlex() {

            Orientation = OrientationEnum.Row;
            Gap = 0;
        }
    }

    internal class Paintable
    {

        public Color FillColor { get; set; }

        public Paintable()
        {
            FillColor = Color.Transparent;
        }
        public Paintable(Color fillColor)
        {
            FillColor = fillColor;
        }
    }

    internal class Padding
    {
        public int Top { get; set; }
        public int Right { get; set; }
        public int Bottom { get; set; }
        public int Left { get; set; }

        public Padding()
        {
            Top = 0;
            Right = 0;
            Bottom = 0;
            Left = 0;
        }
        public Padding(int value)
        {
            Top = value;
            Right = value;
            Bottom = value;
            Left = value;
        }
        public Padding(int valueVertical = 0, int valueHorizontal = 0)
        {
            Top = valueVertical;
            Right = valueHorizontal;
            Bottom = valueVertical;
            Left = valueHorizontal;
        }
        public Padding(int top = 0, int right = 0, int bottom = 0, int left = 0)
        {
            Top = top;
            Right = right;
            Bottom = bottom;
            Left = left;
        }
    }
}
