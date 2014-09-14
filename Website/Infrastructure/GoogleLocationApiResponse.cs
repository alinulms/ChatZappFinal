﻿namespace Website.Infrastructure
{
  using System.Collections.Generic;

  public class Location
  {
    public double lat { get; set; }
    public double lng { get; set; }
  }

  public class Northeast
  {
    public double lat { get; set; }
    public double lng { get; set; }
  }

  public class Southwest
  {
    public double lat { get; set; }
    public double lng { get; set; }
  }

  public class Viewport
  {
    public Northeast northeast { get; set; }
    public Southwest southwest { get; set; }
  }

  public class Geometry
  {
    public Location location { get; set; }
    public Viewport viewport { get; set; }
  }

  public class Result
  {
    public Geometry geometry { get; set; }
    public string icon { get; set; }
    public string id { get; set; }
    public string name { get; set; }
    public string place_id { get; set; }
    public string reference { get; set; }
    public string scope { get; set; }
    public List<string> types { get; set; }
    public string vicinity { get; set; }
  }

  public class GoogleLocationApiResponse
  {
    public List<object> html_attributions { get; set; }
    public List<Result> results { get; set; }
    public string status { get; set; }
  }
}