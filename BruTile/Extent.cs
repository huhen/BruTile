﻿// Copyright (c) BruTile developers team. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Globalization;

namespace BruTile
{
    public struct Extent
    {
        public double MinX { get; private set; }
        public double MinY { get; private set; }
        public double MaxX { get; private set; }
        public double MaxY { get; private set; }

        public double CenterX => (MinX + MaxX) / 2.0;

        public double CenterY => (MinY + MaxY) / 2.0;

        public double Width => MaxX - MinX;

        public double Height => MaxY - MinY;

        public double Area => Width * Height;

        public Extent Intersect(Extent other)
        {
            return new Extent(
                Math.Max(MinX, other.MinX),
                Math.Max(MinY, other.MinY),
                Math.Min(MaxX, other.MaxX),
                Math.Min(MaxY, other.MaxY));
        }

        public Extent(double minX, double minY, double maxX, double maxY) : this()
        {
            MinX = minX;
            MinY = minY;
            MaxX = maxX;
            MaxY = maxY;

            if (minX > maxX || minY > maxY)
            {
                throw new ArgumentException("min should be smaller than max");
            }
        }

        public bool Intersects(Extent box)
        {
            return !(
                        box.MinX > MaxX ||
                        box.MaxX < MinX ||
                        box.MinY > MaxY ||
                        box.MaxY < MinY);
        }

        public override string ToString()
        {
            return String.Format(CultureInfo.InvariantCulture,
                                 "{0},{1},{2},{3}", MinX, MinY, MaxX, MaxY);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Extent))
            {
                return false;
            }
            return Equals((Extent)obj);
        }

        public bool Equals(Extent extent)
        {
            if (MinX != extent.MinX)
            {
                return false;
            }

            if (MinY != extent.MinY)
            {
                return false;
            }

            if (MaxX != extent.MaxX)
            {
                return false;
            }

            if (MaxY != extent.MaxY)
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return MinX.GetHashCode() ^ MinY.GetHashCode() ^ MaxX.GetHashCode() ^ MaxY.GetHashCode();
        }

        public static bool operator ==(Extent extent1, Extent extent2)
        {
            return extent1.Equals(extent2);
        }

        public static bool operator !=(Extent extent1, Extent extent2)
        {
            return !extent1.Equals(extent2);
        }
    }
}