namespace Testcontainers.HashicorpVault;

/// <inheritdoc cref="ContainerBuilder{TBuilderEntity, TContainerEntity, TConfigurationEntity}" />
[PublicAPI]
public sealed class HashicorpVaultBuilder : ContainerBuilder<HashicorpVaultBuilder, HashicorpVaultContainer, HashicorpVaultConfiguration>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HashicorpVaultBuilder" /> class.
    /// </summary>
    public HashicorpVaultBuilder()
        : this(new HashicorpVaultConfiguration())
    {
        // 1) To change the ContainerBuilder default configuration override the DockerResourceConfiguration property and the "HashicorpVaultBuilder Init()" method.
        //    Append the module configuration to base.Init() e.g. base.Init().WithImage("alpine:3.17") to set the modules' default image.

        // 2) To customize the ContainerBuilder validation override the "void Validate()" method.
        //    Use Testcontainers' Guard.Argument<TType>(TType, string) or your own guard implementation to validate the module configuration.

        // 3) Add custom builder methods to extend the ContainerBuilder capabilities such as "HashicorpVaultBuilder WithHashicorpVaultConfig(object)".
        //    Merge the current module configuration with a new instance of the immutable HashicorpVaultConfiguration type to update the module configuration.

        // DockerResourceConfiguration = Init().DockerResourceConfiguration;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="HashicorpVaultBuilder" /> class.
    /// </summary>
    /// <param name="resourceConfiguration">The Docker resource configuration.</param>
    private HashicorpVaultBuilder(HashicorpVaultConfiguration resourceConfiguration)
        : base(resourceConfiguration)
    {
        // DockerResourceConfiguration = resourceConfiguration;
    }

    // /// <inheritdoc />
    // protected override HashicorpVaultConfiguration DockerResourceConfiguration { get; }

    // /// <summary>
    // /// Sets the HashicorpVault config.
    // /// </summary>
    // /// <param name="config">The HashicorpVault config.</param>
    // /// <returns>A configured instance of <see cref="HashicorpVaultBuilder" />.</returns>
    // public HashicorpVaultBuilder WithHashicorpVaultConfig(object config)
    // {
    //     // Extends the ContainerBuilder capabilities and holds a custom configuration in HashicorpVaultConfiguration.
    //     // In case of a module requires other properties to represent itself, extend ContainerConfiguration.
    //     return Merge(DockerResourceConfiguration, new HashicorpVaultConfiguration(config: config));
    // }

    /// <inheritdoc />
    public override HashicorpVaultContainer Build()
    {
        Validate();
        return new HashicorpVaultContainer(DockerResourceConfiguration, TestcontainersSettings.Logger);
    }

    // /// <inheritdoc />
    protected override HashicorpVaultBuilder Init()
    {
        var waitStrategy = Wait.ForUnixContainer().UntilCommandIsCompleted("pg_isready");
        return base.Init().WithImage("hashicorp/vault:latest").WithPortBinding(8200, true).WithWaitStrategy(waitStrategy);
    }

    }

    // /// <inheritdoc />
    // protected override void Validate()
    // {
    //     base.Validate();
    // }

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
}