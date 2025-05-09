// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/weather.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981, 0612
#region Designer generated code

using grpc = global::Grpc.Core;

namespace WeatherServer {
  public static partial class WeatherService
  {
    static readonly string __ServiceName = "weather.WeatherService";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::WeatherServer.WeatherRequest> __Marshaller_weather_WeatherRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::WeatherServer.WeatherRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::WeatherServer.WeatherResponse> __Marshaller_weather_WeatherResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::WeatherServer.WeatherResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::WeatherServer.RepWeatherResponse> __Marshaller_weather_RepWeatherResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::WeatherServer.RepWeatherResponse.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::WeatherServer.WeatherRequest, global::WeatherServer.WeatherResponse> __Method_GetCurrentWeather = new grpc::Method<global::WeatherServer.WeatherRequest, global::WeatherServer.WeatherResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetCurrentWeather",
        __Marshaller_weather_WeatherRequest,
        __Marshaller_weather_WeatherResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::WeatherServer.WeatherRequest, global::WeatherServer.WeatherResponse> __Method_MonitorWeather = new grpc::Method<global::WeatherServer.WeatherRequest, global::WeatherServer.WeatherResponse>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "MonitorWeather",
        __Marshaller_weather_WeatherRequest,
        __Marshaller_weather_WeatherResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::WeatherServer.WeatherRequest, global::WeatherServer.RepWeatherResponse> __Method_GetCurrentWeathers = new grpc::Method<global::WeatherServer.WeatherRequest, global::WeatherServer.RepWeatherResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetCurrentWeathers",
        __Marshaller_weather_WeatherRequest,
        __Marshaller_weather_RepWeatherResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::WeatherServer.WeatherReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of WeatherService</summary>
    [grpc::BindServiceMethod(typeof(WeatherService), "BindService")]
    public abstract partial class WeatherServiceBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::WeatherServer.WeatherResponse> GetCurrentWeather(global::WeatherServer.WeatherRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task MonitorWeather(global::WeatherServer.WeatherRequest request, grpc::IServerStreamWriter<global::WeatherServer.WeatherResponse> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::WeatherServer.RepWeatherResponse> GetCurrentWeathers(global::WeatherServer.WeatherRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(WeatherServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetCurrentWeather, serviceImpl.GetCurrentWeather)
          .AddMethod(__Method_MonitorWeather, serviceImpl.MonitorWeather)
          .AddMethod(__Method_GetCurrentWeathers, serviceImpl.GetCurrentWeathers).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, WeatherServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_GetCurrentWeather, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::WeatherServer.WeatherRequest, global::WeatherServer.WeatherResponse>(serviceImpl.GetCurrentWeather));
      serviceBinder.AddMethod(__Method_MonitorWeather, serviceImpl == null ? null : new grpc::ServerStreamingServerMethod<global::WeatherServer.WeatherRequest, global::WeatherServer.WeatherResponse>(serviceImpl.MonitorWeather));
      serviceBinder.AddMethod(__Method_GetCurrentWeathers, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::WeatherServer.WeatherRequest, global::WeatherServer.RepWeatherResponse>(serviceImpl.GetCurrentWeathers));
    }

  }
}
#endregion
