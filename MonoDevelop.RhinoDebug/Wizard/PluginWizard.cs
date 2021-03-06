﻿using System;
using MonoDevelop.Ide.Templates;
using MonoDevelop.Ide.Projects;
using System.Collections.Generic;

namespace MonoDevelop.RhinoDebug.Wizard
{
  public class PluginWizard : TemplateWizard
  {
    public override string Id => "MonoDevelop.RhinoDebug.PluginWizard";

    public bool ProvideCodeSample { get; set; } = true;
    public int RhinoVersion { get; set; } = 6;

    public override void ConfigureWizard()
    {
      base.ConfigureWizard();

      Parameters["IncludeSample"] = ProvideCodeSample.ToString();
      Parameters["RhinoVersion"] = RhinoVersion.ToString();
      Parameters["Rhino5Location"] = Helpers.FindRhinoWithVersion(5);

      // provide some guid's for our templates
      for (int i = 0; i < 10; i++)
      {
        Parameters["Guid" + i] = Guid.NewGuid().ToString();
      }
    }

    public override IEnumerable<ProjectConfigurationControl> GetFinalPageControls()
    {
      yield return new ProvideSampleControl(this);
      yield return new RhinoVersionControl(this);
    }

    public override int TotalPages => 0;

    public override WizardPage GetPage(int pageNumber)
    {
      return null;
    }
  }
}