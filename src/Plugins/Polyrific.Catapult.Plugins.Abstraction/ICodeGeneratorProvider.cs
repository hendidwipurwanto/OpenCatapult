﻿// Copyright (c) Polyrific, Inc 2018. All rights reserved.

using System.Collections.Generic;
using System.Threading.Tasks;
using Polyrific.Catapult.Plugins.Abstraction.Configs;
using Polyrific.Catapult.Shared.Dto.ProjectDataModel;

namespace Polyrific.Catapult.Plugins.Abstraction
{
    public interface ICodeGeneratorProvider
    {
        /// <summary>
        /// Name of the provider
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Required service connections
        /// </summary>
        string[] RequiredServices { get; }

        /// <summary>
        /// Process to run before executing the code generation
        /// </summary>
        /// <param name="projectName">Name of the project</param>
        /// <param name="models">Project data models</param>
        /// <param name="outputFolderName">Name of the output folder</param>
        /// <param name="config">Generate task configuration</param>
        /// <returns>Error message</returns>
        Task<string> BeforeGenerate(string projectName, List<ProjectDataModelDto> models, string outputFolderName, GenerateTaskConfig config);

        /// <summary>
        /// Generate code from data models
        /// </summary>
        /// <param name="projectName">Name of the project</param>
        /// <param name="models">Project data models</param>
        /// <param name="outputFolderName">Name of the output folder</param>
        /// <param name="config">Generate task configuration</param>
        /// <returns></returns>
        Task<(string outputLocation, string errorMessage)> Generate(string projectName, List<ProjectDataModelDto> models, string outputFolderName, GenerateTaskConfig config);

        /// <summary>
        /// Process to run after executing code generation
        /// </summary>
        /// <param name="projectName">Name of the project</param>
        /// <param name="models">Project data models</param>
        /// <param name="outputFolderName">Name of the output folder</param>
        /// <param name="config">Generate task configuration</param>
        /// <returns>Error message</returns>
        Task<string> AfterGenerate(string projectName, List<ProjectDataModelDto> models, string outputFolderName, GenerateTaskConfig config);
    }
}