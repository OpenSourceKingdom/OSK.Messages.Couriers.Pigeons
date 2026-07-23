using Microsoft.Extensions.DependencyInjection;
using OSK.Extensions.Couriers.Pigeons.Messaging.Internal.Services;
using OSK.Extensions.Couriers.Pigeons.Messaging.Ports;
using OSK.Messages.Couriers.Pigeons;
using OSK.Messages.Messaging;
using System;

namespace OSK.Extensions.Couriers.Pigeons.Messaging;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds a messaging system that primarily utilizes a local courier to perform its tasks, using a custom build action
    /// </summary>
    /// <param name="services">The services to add the dependencies to</param>
    /// <param name="configurator">The configuration to use for the local messaging sytem</param>
    /// <returns>The services for chaining</returns>
    /// <exception cref="ArgumentNullException">If builder configuration is null</exception>
    public static IServiceCollection AddPigeonMessaging(this IServiceCollection services, Action<IPigeonMessagingConfigurator> configurator)
    {
        if (configurator is null)
        {
            throw new ArgumentNullException(nameof(configurator));
        }

        var pigeonConfigurator = new MessagingConfigurator();
        configurator(pigeonConfigurator);

        pigeonConfigurator.Validate();

        services.AddMessaging(pigeonConfigurator.MessageCenterConfigurator!);
        services.AddCourierPigeons(pigeonConfigurator.OptionsConfigurator);

        return services;
    }
}
