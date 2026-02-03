using RetroRides.Data.Models;
using RetroRides.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroRides.Utilities
{
    public static class InvoiceHelper
    {
        public static string GenerateOrderInvoice(Order order)
        {
            var sb = new StringBuilder();
            sb.AppendLine("========== RETRORIDES INVOICE ==========");
            sb.AppendLine($"Invoice #: {order.Id.ToString().Substring(0, 8).ToUpper()}");
            sb.AppendLine($"Date:      {order.OrderDate:dd.MM.yyyy HH:mm}");
            sb.AppendLine("----------------------------------------");
            sb.AppendLine("BUYER DETAILS:");
            sb.AppendLine($"Name:    {order.User?.Username ?? "N/A"}");
            sb.AppendLine($"Phone:   {order.PhoneNumber}");
            sb.AppendLine($"Address: {order.DeliveryAddress}");
            sb.AppendLine("----------------------------------------");
            sb.AppendLine("ITEMS:");

            foreach (var item in order.OrderItems)
            {
                string name = item.Souvenir?.Name ?? "Unknown Item";
                sb.AppendLine($"- {name,-20} x{item.Quantity}  {item.UnitPrice * item.Quantity:F2} BGN");
            }

            sb.AppendLine("----------------------------------------");
            sb.AppendLine($"TOTAL AMOUNT:          {order.TotalAmount:F2} BGN");
            sb.AppendLine("========================================");
            sb.AppendLine("Thank you for choosing RetroRides!");

            return sb.ToString();
        }

        public static string GenerateReservationTicket(Reservation reservation)
        {
            var sb = new StringBuilder();
            sb.AppendLine("========== MUSEUM VISIT TICKET ==========");
            sb.AppendLine($"Ticket #: {reservation.Id.ToString().Substring(0, 8).ToUpper()}");
            sb.AppendLine($"Date:     {reservation.DateOfVisit:dd.MM.yyyy HH:mm}");
            sb.AppendLine("-----------------------------------------");
            sb.AppendLine($"Visitor: {reservation.User?.Username}");
            if (!string.IsNullOrEmpty(reservation.Notes))
            {
                sb.AppendLine($"Notes:   {reservation.Notes}");
            }
            sb.AppendLine("-----------------------------------------");
            sb.AppendLine("Status:  CONFIRMED");
            sb.AppendLine("=========================================");

            return sb.ToString();
        }
    }
}
