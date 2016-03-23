﻿using System;
using System.Collections.Generic;
using System.Text;
using PdfSharp.Drawing;

namespace PdfSharp.Xps.XpsModel
{
  /// <summary>
  /// A series of Bézier segments.
  /// </summary>
  class PolyBezierSegment : PathSegment
  {
    /// <summary>
    /// Gets the smallest rectangle that completely contains all points of the segments.
    /// </summary>
    public override XRect GetBoundingBox()
    {
      return Points.GetBoundingBox();
    }

    /// <summary>
    /// Specifies whether the stroke for this segment of the path is drawn. Can be true or false. 
    /// </summary>
    public bool IsStroked { get; set; }

    /// <summary>
    /// Specifies control points for multiple Bézier segments. Coordinate values within each pair are 
    /// comma-separated and additional whitespace may appear. Coordinate pairs are separated 
    /// from other coordinate pairs by whitespace. 
    /// </summary>
    public PointStopCollection Points = new PointStopCollection();
  }
}