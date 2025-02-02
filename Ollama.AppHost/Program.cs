
using Aspire.Hosting;
using OllamaSharp;

var builder = DistributedApplication.CreateBuilder(args);

var container = builder.AddDockerfile("mycontainer", "./");

var ollama = builder.AddOllama("Ollama")
                    .WithDataVolume()
                    .WithGPUSupport()
                    .WithLifetime(ContainerLifetime.Persistent)
                    .WithOpenWebUI()
                    .WithEndpoint(11434, 11434, name: "ollamaapi")
                    .WithEndpoint(3000, 3000, name: "ollamawebui");

var deepseek = ollama.AddModel("deepseek-r1:8b");

builder.Build().Run();
