// Copyright (c) BruTile developers team. All rights reserved. See License.txt in the project root for license information.

namespace BruTile
{
    public struct Resolution
    {
        public Resolution(string id, double unitsPerPixel, 
            int tileWidth = 256, int tileHeight = 256,
            double left = 0, double top = 0,
            int matrixWidth = 0, int matrixHeight = 0,
            double scaledenominator = 0)
        {
            Id = id;
            UnitsPerPixel = unitsPerPixel;
            TileWidth = tileWidth;
            TileHeight = tileHeight;
            MatrixWidth = matrixWidth;
            MatrixHeight = matrixHeight;
            Top = top;
            Left = left;
            ScaleDenominator = scaledenominator;
        }

        public string Id { get; }

        public double UnitsPerPixel { get; }

        public double ScaleDenominator { get; }

        public double Top { get; }

        public double Left { get; }

        public int TileWidth { get; }

        public int TileHeight { get; }

        public int MatrixWidth { get; }

        public int MatrixHeight { get; }
    }
}