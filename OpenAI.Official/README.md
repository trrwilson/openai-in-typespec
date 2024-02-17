## Project setup

Temporary bootstrap:

- Full code generation via `npx tsp compile .`
- "Replace all" to put codegen into an .Internal namespace and be internal
- Treat `/Custom` as standalone code that selectively pulls in `.Internal` namespace functionality
- Most Custom types compose one or more `Internal.` counterparts
- All "real work" still goes through generated code




## Examples


### Embeddings

Simple case: generate a single embedding from a string:

```csharp
EmbeddingClient client = new("text-embedding-ada-002");
Result<Embedding> result = client.GenerateEmbedding("Hello, world!");
ReadOnlyMemory<float> embeddings = result.Value.Vector;
```

More complex case: generate embeddings for several inputs with `dimensions`
specified:

```csharp
EmbeddingClient client = new("text-embedding-3-small");

string
List<string> prompts =
[
    "Hello, world!",
    "This is a test.",
    "Goodbye!"
];
EmbeddingOptions options = new()
{
    Dimensions = 456,
};
Result<EmbeddingCollection> response = client.GenerateEmbeddings(prompts, options);
foreach (Embedding embedding in result.Value)
{
    float[] array = embedding.Vector.ToArray();
    Console.WriteLine($"Index {i}: {array.Length} values");
}
```