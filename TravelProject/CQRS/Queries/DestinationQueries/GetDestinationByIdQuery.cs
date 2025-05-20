using MediatR;
using TravelProject.CQRS.Results.DestinationResults;

namespace TravelProject.CQRS.Queries.DestinationQueries
{
	public class GetDestinationByIdQuery : IRequest<GetDestinationByIdQueryResult>
	{
		/*
		Mediator -> Arabulucu, aracı   Mediat -> Ara bulucu
		MediatR -> Farklı katmanların birbiriyle doğrudan konuşmasını engelleyerek tüm işlemleri Handler'lar üzerinden
		gerçekleştiren tasarım desenidir.Controller sadece Query veya Command 'ı Send() metoduna parametre olarak verir
		ve devamında MediatR bu isteği işleyen doğru Handler'ı bulur ve devamında Handler da isteğe uygun yanıtı döner.
		Yani Controller, Handler,Query,Result ve Command class'larını ve bunların ne yaptığını hangisi hangisi ile eşleşiyor
		bunları bilmez sadece IMediator.Send() metoduna parametre olarak gönderir

		IRequest<TResponse> -> MediatR isteğidir ve TResponse tipinde bir cevap bekler. Sorgunun geriye ne döndürmesi 
		gerektiğini belirtiyoruz. Örnek verikcek olursak:
		"GetDestinationByIdQuery : IRequest<GetDestinationByIdQueryResult>" bu ifade şu demektir:
		"GetDestinationByIdQuery" sorgusunu işleyecek olan Handler geriye sadece "GetDestinationByIdQueryResult" tipinde
		cevap dönmesi gerecektir.

		IRequestHandler<TRequest, TResponse> -> Bu Interface'i impelement eden Handler Class'ının hangi isteği işleyeceğini ve
		sonucunda hangi tipte(Class) cevap döneceğini kesin bir şekilde belirtiyoruz. 
		Yani sadece TRequest tipindeki sorguları işler, ve geriye sadece TResponse tipinde cevap döner.
		Yani TRequest tipi dışında istekleri alamaz, TResponse tipi dışında da yanıtı kesinlikle dönemez.

		Böylelikle MediatR, IMediator.Send(TRequest) metodu ile TRequest tipinde istek geldiğinde isteğe uygun Handler'i eşliyor 
		ve bu handler'ı çağrıyor. Handler ise "IRequestHandler<TRequest, TResponse>" interface'i impelement ettiğinden 
        dolayı o isteğe uygun TResponse döndürüyor.


			 */
		public int Id { get; set; }

		public GetDestinationByIdQuery(int id)
		{
			Id = id;
		}
	}
}
