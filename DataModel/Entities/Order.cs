using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace DataModel.Entities
{
    public class Order : BaseEntity
    {
        [DisplayName("Име"),Column(Order =2)]
        public string FirstName { get; set; }
        [DisplayName("Фамилия"), Column(Order = 3)]
        public string LastName { get; set; }
        [DisplayName("Тел. Номер"), Column(Order = 4)]
        public string PhoneNumber { get; set; }
        [DisplayName("E-mail"), Column(Order = 5)]
        public string Email { get; set; }
        [DisplayName("Изделие"), Column(Order = 6)]
        public string TypeOfProduct { get; set; }
        [DisplayName("Сериен No."), Column(Order = 7)]
        public string SerialNum { get; set; }
        [DisplayName("Комплектовка"), Column(Order = 8)]
        public string Komplektovka { get; set; }
        [DisplayName("Неизправност"), Column(Order = 9)]
        public string Neizpravnost { get; set; }
        [DisplayName("Забележки"), Column(Order = 10)]
        public string Zabelejki { get; set; }
        [DisplayName("Приел Поръчката"), Column(Order = 11)]
        public string PrielPoruchka { get; set; }
        [DisplayName("Изпълнил поръчката"), Column(Order = 12)]
        public string IzpulnilPoruchka { get; set; }
        [DisplayName("Статус на поръчката"), Column(Order = 13)]
        public string OrderStatus { get; set; }
        [DisplayName("Извършена работа"),Column(Order =14)]
        public string WorkDone { get; set; }
        [DisplayName("Дата на поръчката"),Column(Order=15,TypeName ="datetime")]
        public DateTime DateOfOrder { get; set; }
    }
}
