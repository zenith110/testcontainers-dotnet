namespace Testcontainers.HashicorpVault;

/// <inheritdoc cref="DockerContainer" />
[PublicAPI]
public sealed class HashicorpVaultContainer : DockerContainer
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HashicorpVaultContainer" /> class.
    /// </summary>
    /// <param name="configuration">The container configuration.</param>
    public HashicorpVaultContainer(HashicorpVaultConfiguration configuration)
        : base(configuration)
    {
    }
}