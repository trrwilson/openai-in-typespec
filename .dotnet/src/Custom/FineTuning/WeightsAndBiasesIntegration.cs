using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace OpenAI.FineTuning;

/// <summary>
/// Setting for integration with Weights and Biases (https://wandb.ai).
/// </summary>
[CodeGenModel("CreateFineTuningJobRequestWandbIntegration")]
[CodeGenSuppress(nameof(WeightsAndBiasesIntegration), typeof(string), typeof(IDictionary<string, BinaryData>), typeof(string), typeof(string), typeof(string), typeof(IList<string>))]
public partial class WeightsAndBiasesIntegration
{
    [CodeGenMember("Project")]
    private string _project;

    /// <summary>
    /// The Weights &amp; Biases <c>project</c> name that the run will be created under.
    /// </summary>
    public required string ProjectName
    {
        get => _project;
        set => _project = value;
    }

    /// <summary>
    /// The friendly <c>name</c> to associate with the run. If not specified, the job ID will be used.
    /// </summary>
    [CodeGenMember("Name")]
    public string DisplayName { get; set; }

    /// <summary>
    /// The Weights &amp; Biases <c>entity</c> to associate with the run, specified as a team or user name.
    /// </summary>
    [CodeGenMember("Entity")]
    public string EntityName { get; set; }

    public WeightsAndBiasesIntegration()
        : base("wandb", null)
    {}

    [SetsRequiredMembers]
    public WeightsAndBiasesIntegration(string projectName)
    {
        ProjectName = projectName;
    }

    [SetsRequiredMembers]
    internal WeightsAndBiasesIntegration(string type, IDictionary<string, BinaryData> serializedAdditionalRawData, string project, string displayName, string entityName, IList<string> tags)
        : base(type, serializedAdditionalRawData)
    {
        _project = project;
        DisplayName = displayName;
        EntityName = entityName;
        Tags = tags;
    }
}