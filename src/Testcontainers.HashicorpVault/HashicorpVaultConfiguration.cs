namespace Testcontainers.HashicorpVault;

/// <inheritdoc cref="ContainerConfiguration" />
[PublicAPI]
public sealed class HashicorpVaultConfiguration : ContainerConfiguration
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HashicorpVaultConfiguration" /> class.
    /// </summary>
    /// <param name="config">The HashicorpVault config.</param>
    public HashicorpVaultConfiguration(string VAULT_DEV_ROOT_TOKEN_ID = null, string VAULT_DEV_LISTEN_ADDRESS = null)
    {
        // // Sets the custom builder methods property values.
        // Config = config;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="HashicorpVaultConfiguration" /> class.
    /// </summary>
    /// <param name="resourceConfiguration">The Docker resource configuration.</param>
    public HashicorpVaultConfiguration(IResourceConfiguration<CreateContainerParameters> resourceConfiguration)
        : base(resourceConfiguration)
    {
        // Passes the configuration upwards to the base implementations to create an updated immutable copy.
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="HashicorpVaultConfiguration" /> class.
    /// </summary>
    /// <param name="resourceConfiguration">The Docker resource configuration.</param>
    public HashicorpVaultConfiguration(IContainerConfiguration resourceConfiguration)
        : base(resourceConfiguration)
    {
        // Passes the configuration upwards to the base implementations to create an updated immutable copy.
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="HashicorpVaultConfiguration" /> class.
    /// </summary>
    /// <param name="resourceConfiguration">The Docker resource configuration.</param>
    public HashicorpVaultConfiguration(HashicorpVaultConfiguration resourceConfiguration)
        : this(new HashicorpVaultConfiguration(), resourceConfiguration)
    {
        // Passes the configuration upwards to the base implementations to create an updated immutable copy.
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="HashicorpVaultConfiguration" /> class.
    /// </summary>
    /// <param name="oldValue">The old Docker resource configuration.</param>
    /// <param name="newValue">The new Docker resource configuration.</param>
    public HashicorpVaultConfiguration(HashicorpVaultConfiguration oldValue, HashicorpVaultConfiguration newValue)
        : base(oldValue, newValue)
    {
        // // Create an updated immutable copy of the module configuration.
        // Config = BuildConfiguration.Combine(oldValue.Config, newValue.Config);
        VAULT_DEV_LISTEN_ADDRESS = BuildConfiguration.Combine(oldValue.VAULT_DEV_LISTEN_ADDRESS, newValue.VAULT_DEV_LISTEN_ADDRESS);
        VAULT_DEV_ROOT_TOKEN_ID = BuildConfiguration.Combine(oldValue.VAULT_DEV_ROOT_TOKEN_ID, newValue.VAULT_DEV_ROOT_TOKEN_ID);
    }

    // /// <summary>
    // /// Gets the HashicorpVault config.
    // /// </summary>
    // public object Config { get; }
    public string VAULT_DEV_LISTEN_ADDRESS { get; }
    public string VAULT_DEV_ROOT_TOKEN_ID { get; }

}