using OSK.Hexagonal.MetaData;
using OSK.Messages.Couriers.Pigeons.Options;
using OSK.Messages.Messaging.Ports;
using System;

namespace OSK.Extensions.Couriers.Pigeons.Messaging.Ports;

[HexagonalIntegration(HexagonalIntegrationType.LibraryProvided)]
public interface IPigeonMessagingConfigurator
{
    /// <summary>
    /// Configures the messaging center that will be used
    /// </summary>
    /// <param name="builderConfiguration">The configuration to apply</param>
    /// <returns>The configurator for chaining</returns>
    IPigeonMessagingConfigurator ConfigureMessageCenter(Action<IMessageCenterBuilder> builderConfiguration);

    /// <summary>
    /// Configures the courier pigeon options
    /// </summary>
    /// <param name="optionConfigurator">The configuration to apply</param>
    /// <returns>The configurator for chaining</returns>
    IPigeonMessagingConfigurator WithPigeonOptions(Action<PigeonOptions> optionConfigurator);
}
