var builder = DistributedApplication.CreateBuilder(args);

var mvcApp = builder.AddProject<Projects.PromptBox_WebApp>("promptbox-webapp");

builder.Build().Run();
