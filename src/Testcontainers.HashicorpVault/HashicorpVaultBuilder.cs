namespace Testcontainers.HashicorpVault;

/// <inheritdoc cref="ContainerBuilder{TBuilderEntity, TContainerEntity, TConfigurationEntity}" />
[PublicAPI]
public sealed class HashicorpVaultBuilder : ContainerBuilder<HashicorpVaultBuilder, HashicorpVaultContainer, HashicorpVaultConfiguration>
{
    public const string HashicorpVaultImage = "docker.io/hashicorp/vault:1.16";

    public const ushort HashicorpVaultPort = 8200;

    /// <summary>
    /// Initializes a new instance of the <see cref="HashicorpVaultBuilder" /> class.
    /// </summary>
    public HashicorpVaultBuilder()
        : this(new HashicorpVaultConfiguration())
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="HashicorpVaultBuilder" /> class.
    /// </summary>
    /// <param name="resourceConfiguration">The Docker resource configuration.</param>
    private HashicorpVaultBuilder(HashicorpVaultConfiguration resourceConfiguration)
        : base(resourceConfiguration)
    {
        DockerResourceConfiguration = resourceConfiguration;
    }

    /// <inheritdoc />
    public override HashicorpVaultContainer Build()
    {
        Validate();
        return new HashicorpVaultContainer(DockerResourceConfiguration, TestcontainersSettings.Logger);
    }

    // /// <inheritdoc />
    protected override HashicorpVaultBuilder Init()
    {
        return base.Init()
            .WithImage(HashicorpVaultImage)
            .WithPortBinding(HashicorpVaultPort, true)
            .WithWaitStrategy(Wait.ForUnixContainer().AddCustomWaitStrategy(new WaitUntil()));
    }

    
    // /// <inheritdoc />
    protected override void Validate()
    {
        base.Validate();
        _ = Guard.Argument(DockerResourceConfiguration.VAULT_DEV_ROOT_TOKEN_ID, nameof(HashicorpVaultConfiguration.VAULT_DEV_ROOT_TOKEN_ID))
        .NotNull()
        .NotEmpty();

        _ = Guard.Argument(DockerResourceConfiguration.VAULT_DEV_LISTEN_ADDRESS, nameof(HashicorpVaultConfiguration.VAULT_DEV_LISTEN_ADDRESS))
        .NotNull()
        .NotEmpty();
    }

    /// <inheritdoc />
    protected override HashicorpVaultBuilder Clone(IResourceConfiguration<CreateContainerParameters> resourceConfiguration)
    {
        return Merge(DockerResourceConfiguration, new HashicorpVaultConfiguration(resourceConfiguration));
    }

    /// <inheritdoc />
    protected override HashicorpVaultBuilder Clone(IContainerConfiguration resourceConfiguration)
    {
        return Merge(DockerResourceConfiguration, new HashicorpVaultConfiguration(resourceConfiguration));
    }

    /// <inheritdoc />
    protected override HashicorpVaultBuilder Merge(HashicorpVaultConfiguration oldValue, HashicorpVaultConfiguration newValue)
    {
        return new HashicorpVaultBuilder(new HashicorpVaultConfiguration(oldValue, newValue));
    }

    /// <summary>
    /// Sets the environment variable for the root token id to sign in
    /// </summary>
    /// <param name="vaultDevRootTokenID">The Hashicorp Vault root token id used to sign in.</param>
    /// <returns>A configured instance of <see cref="HashicorpVaultBuilder" />.</returns>
    public HashicorpVaultBuilder WithVaultDevRootTokenID(string vaultDevRootTokenID){
        return Merge(DockerResourceConfiguration, new HashicorpVaultConfiguration(VAULT_DEV_ROOT_TOKEN_ID: vaultDevRootTokenID))
            .WithEnvironment("VAULT_DEV_ROOT_TOKEN_ID", vaultDevRootTokenID);
    }

    /// <summary>
    /// Sets the listening address for the dev vault instance
    /// </summary>
    /// <param name="vaultDevListenAddress">The listening address for the dev vault container</param>
    /// <returns>A configured instance of <see cref="HashicorpVaultBuilder" />.</returns>
    public HashicorpVaultBuilder WithVaultDevListenAddress(string vaultDevListenAddress){
        return Merge(DockerResourceConfiguration, new HashicorpVaultConfiguration(VAULT_DEV_LISTEN_ADDRESS: vaultDevListenAddress))
            .WithEnvironment("VAULT_DEV_LISTEN_ADDRESS", vaultDevListenAddress);
    }

}