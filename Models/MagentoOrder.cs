using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_SAP.Models
{
    public class MagentoOrder
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Address
    {
        public string address_type { get; set; }
        public string city { get; set; }
        public string country_id { get; set; }
        public int customer_address_id { get; set; }
        public string email { get; set; }
        public int entity_id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public int parent_id { get; set; }
        public string postcode { get; set; }
        public string region { get; set; }
        public string region_code { get; set; }
        public int region_id { get; set; }
        public List<string> street { get; set; }
        public string telephone { get; set; }
        public string vat_id { get; set; }
    }

    public class BillingAddress
    {
        public string address_type { get; set; }
        public string city { get; set; }
        public string country_id { get; set; }
        public int customer_address_id { get; set; }
        public string email { get; set; }
        public int entity_id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public int parent_id { get; set; }
        public string postcode { get; set; }
        public string region { get; set; }
        public string region_code { get; set; }
        public int region_id { get; set; }
        public List<string> street { get; set; }
        public string telephone { get; set; }
        public string vat_id { get; set; }
    }

    public class Item
    {
        public int amount_refunded { get; set; }
        public int base_amount_refunded { get; set; }
        public int base_discount_amount { get; set; }
        public int base_discount_invoiced { get; set; }
        public int base_discount_tax_compensation_amount { get; set; }
        public double base_original_price { get; set; }
        public double base_price { get; set; }
        public double base_price_incl_tax { get; set; }
        public int base_row_invoiced { get; set; }
        public double base_row_total { get; set; }
        public double base_row_total_incl_tax { get; set; }
        public int base_tax_amount { get; set; }
        public int base_tax_invoiced { get; set; }
        public string created_at { get; set; }
        public int discount_amount { get; set; }
        public int discount_invoiced { get; set; }
        public int discount_percent { get; set; }
        public int free_shipping { get; set; }
        public int discount_tax_compensation_amount { get; set; }
        public int discount_tax_compensation_canceled { get; set; }
        public int is_qty_decimal { get; set; }
        public int is_virtual { get; set; }
        public int item_id { get; set; }
        public string name { get; set; }
        public int no_discount { get; set; }
        public int order_id { get; set; }
        public double original_price { get; set; }
        public double price { get; set; }
        public double price_incl_tax { get; set; }
        public int product_id { get; set; }
        public string product_type { get; set; }
        public int qty_canceled { get; set; }
        public int qty_invoiced { get; set; }
        public int qty_ordered { get; set; }
        public int qty_refunded { get; set; }
        public int qty_shipped { get; set; }
        public int quote_item_id { get; set; }
        public int row_invoiced { get; set; }
        public double row_total { get; set; }
        public double row_total_incl_tax { get; set; }
        public double row_weight { get; set; }
        public string sku { get; set; }
        public int store_id { get; set; }
        public int tax_amount { get; set; }
        public int tax_canceled { get; set; }
        public int tax_invoiced { get; set; }
        public int tax_percent { get; set; }
        public string updated_at { get; set; }
        public double weight { get; set; }
    }

    public class Payment
    {
        public object account_status { get; set; }
        public List<object> additional_information { get; set; }
        public double amount_ordered { get; set; }
        public double base_amount_ordered { get; set; }
        public double base_shipping_amount { get; set; }
        public string cc_exp_year { get; set; }
        public object cc_last4 { get; set; }
        public string cc_ss_start_month { get; set; }
        public string cc_ss_start_year { get; set; }
        public int entity_id { get; set; }
        public string last_trans_id { get; set; }
        public string method { get; set; }
        public int parent_id { get; set; }
        public double shipping_amount { get; set; }
    }

    public class Root
    {
        public string base_currency_code { get; set; }
        public int base_discount_amount { get; set; }
        public int base_discount_canceled { get; set; }
        public double base_grand_total { get; set; }
        public int base_discount_tax_compensation_amount { get; set; }
        public double base_shipping_amount { get; set; }
        public double base_shipping_canceled { get; set; }
        public int base_shipping_discount_amount { get; set; }
        public int base_shipping_discount_tax_compensation_amnt { get; set; }
        public double base_shipping_incl_tax { get; set; }
        public int base_shipping_tax_amount { get; set; }
        public double base_subtotal { get; set; }
        public double base_subtotal_canceled { get; set; }
        public double base_subtotal_incl_tax { get; set; }
        public int base_tax_amount { get; set; }
        public int base_tax_canceled { get; set; }
        public double base_total_canceled { get; set; }
        public double base_total_due { get; set; }
        public int base_to_global_rate { get; set; }
        public int base_to_order_rate { get; set; }
        public int billing_address_id { get; set; }
        public string created_at { get; set; }
        public string customer_email { get; set; }
        public string customer_firstname { get; set; }
        public int customer_group_id { get; set; }
        public int customer_id { get; set; }
        public int customer_is_guest { get; set; }
        public string customer_lastname { get; set; }
        public string customer_note { get; set; }
        public int customer_note_notify { get; set; }
        public string customer_taxvat { get; set; }
        public int discount_amount { get; set; }
        public int discount_canceled { get; set; }
        public int email_sent { get; set; }
        public int entity_id { get; set; }
        public string ext_order_id { get; set; }
        public string global_currency_code { get; set; }
        public double grand_total { get; set; }
        public int discount_tax_compensation_amount { get; set; }
        public string increment_id { get; set; }
        public int is_virtual { get; set; }
        public string order_currency_code { get; set; }
        public string protect_code { get; set; }
        public int quote_id { get; set; }
        public string remote_ip { get; set; }
        public double shipping_amount { get; set; }
        public double shipping_canceled { get; set; }
        public string shipping_description { get; set; }
        public int shipping_discount_amount { get; set; }
        public int shipping_discount_tax_compensation_amount { get; set; }
        public double shipping_incl_tax { get; set; }
        public int shipping_tax_amount { get; set; }
        public string state { get; set; }
        public string status { get; set; }
        public string store_currency_code { get; set; }
        public int store_id { get; set; }
        public string store_name { get; set; }
        public int store_to_base_rate { get; set; }
        public int store_to_order_rate { get; set; }
        public double subtotal { get; set; }
        public double subtotal_canceled { get; set; }
        public double subtotal_incl_tax { get; set; }
        public int tax_amount { get; set; }
        public int tax_canceled { get; set; }
        public double total_canceled { get; set; }
        public double total_due { get; set; }
        public int total_item_count { get; set; }
        public int total_qty_ordered { get; set; }
        public string updated_at { get; set; }
        public double weight { get; set; }
        public List<Item> items { get; set; }
        public BillingAddress billing_address { get; set; }
        public Payment payment { get; set; }
        public List<StatusHistory> status_histories { get; set; }
        
    }

    public class Shipping
    {
        public Address address { get; set; }
        public string method { get; set; }
        public Total total { get; set; }
    }

    public class ShippingAssignment
    {
        public Shipping shipping { get; set; }
        public List<Item> items { get; set; }
    }

    public class StatusHistory
    {
        public string comment { get; set; }
        public string created_at { get; set; }
        public int entity_id { get; set; }
        public string entity_name { get; set; }
        public int? is_customer_notified { get; set; }
        public int is_visible_on_front { get; set; }
        public int parent_id { get; set; }
        public string status { get; set; }
    }

    public class Total
    {
        public double base_shipping_amount { get; set; }
        public double base_shipping_canceled { get; set; }
        public int base_shipping_discount_amount { get; set; }
        public int base_shipping_discount_tax_compensation_amnt { get; set; }
        public double base_shipping_incl_tax { get; set; }
        public int base_shipping_tax_amount { get; set; }
        public double shipping_amount { get; set; }
        public double shipping_canceled { get; set; }
        public int shipping_discount_amount { get; set; }
        public int shipping_discount_tax_compensation_amount { get; set; }
        public double shipping_incl_tax { get; set; }
        public int shipping_tax_amount { get; set; }
    }


    }
}