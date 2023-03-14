using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using mission9_mcurzon1.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace mission9_mcurzon1.Models
{
    public class SessionBasket : Basket
    {
        public static Basket GetBasket (IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            SessionBasket basket = session?.GetJson<SessionBasket>("Basket") ?? new SessionBasket();
            basket.Session = session;
            return basket;
        }
        [JsonIgnore]
        public ISession Session { get; set; }
        public static SessionBasket ISession { get; private set; }

        public override void AddItem(Book book, double price, int qty)
        {
            base.AddItem(book, price, qty);
            Session.SetJson("Basket", this);
        }
        public override void RemoveItem(Book b)
        {
            base.RemoveItem(b);
            Session.SetJson("Basket", this);
        }
        public override void ClearBasket()
        {
            base.ClearBasket();
            Session.SetJson("Basket", this);
        }
    }
}
