﻿namespace TravelProject.Areas.Admin.Models
{
	public class BookingHotelSeachViewModel
	{

		public string? dest_id { get; set; }
		public double? primary_count { get; set; }
		public double? count { get; set; }
		public Room_Distribution[] room_distribution { get; set; }
		public Map_Bounding_Box map_bounding_box { get; set; }
		public double? total_count_with_filters { get; set; }
		public double? unfiltered_count { get; set; }
		public double? extended_count { get; set; }
		public double? unfiltered_primary_count { get; set; }
		public double? search_radius { get; set; }
		public Sort[] sort { get; set; }
		public Result[] result { get; set; }


		public class Map_Bounding_Box
		{
			public float? sw_long { get; set; }
			public float? ne_lat { get; set; }
			public float? ne_long { get; set; }
			public float? sw_lat { get; set; }
		}

		public class Room_Distribution
		{
			public double?[] children { get; set; }
			public string adults { get; set; }
		}

		public class Sort
		{
			public string id { get; set; }
			public string name { get; set; }
		}

		public class Result
		{
			public double? preferred { get; set; }
			public double? is_free_cancellable { get; set; }
			public double? native_ads_cpc { get; set; }
			public double? is_genius_deal { get; set; }
			public object updated_checkin { get; set; }
			public string review_recommendation { get; set; }
			public Composite_Price_Breakdown composite_price_breakdown { get; set; }
			public string timezone { get; set; }
			public double? is_tpi_exclusive_property { get; set; }
			public string country_trans { get; set; }
			public string native_ad_id { get; set; }
			public float? mobile_discount_percentage { get; set; }
			public string[] block_ids { get; set; }
			public double? preferred_plus { get; set; }
			public double? is_no_prepayment_block { get; set; }
			public double? wishlist_count { get; set; }
			public string city_in_trans { get; set; }
			public double? is_mobile_deal { get; set; }
			public double? cc_required { get; set; }
			public float? longitude { get; set; }
			public Checkin checkin { get; set; }
			public string default_language { get; set; }
			public double? hotel_has_vb_boost { get; set; }
			public double? children_not_allowed { get; set; }
			public Badge[] badges { get; set; }
			public string native_ads_tracking { get; set; }
			public string review_score_word { get; set; }
			public string main_photo_url { get; set; }
			public double? is_city_center { get; set; }
			public string distance_to_cc { get; set; }
			public double? _class { get; set; }
			public Matching_Units_Configuration matching_units_configuration { get; set; }
			public double? genius_discount_percentage { get; set; }
			public string currency_code { get; set; }
			public double? district_id { get; set; }
			public Price_Breakdown price_breakdown { get; set; }
			public string city_name_en { get; set; }
			public object is_geo_rate { get; set; }
			public string url { get; set; }
			public string unit_configuration_label { get; set; }
			public string address { get; set; }
			public string accommodation_type_name { get; set; }
			public double? in_best_district { get; set; }
			public object selected_review_topic { get; set; }
			public double? soldout { get; set; }
			public string default_wishlist_name { get; set; }
			public string address_trans { get; set; }
			public double? main_photo_id { get; set; }
			public Booking_Home booking_home { get; set; }
			public string distance_to_cc_formatted { get; set; }
			public double? hotel_include_breakfast { get; set; }
			public double? class_is_estimated { get; set; }
			public string crib_guaranteed { get; set; }
			public double? accommodation_type { get; set; }
			public Checkout checkout { get; set; }
			public float? review_score { get; set; }
			public double? review_nr { get; set; }
			public double? is_smart_deal { get; set; }
			public string cc1 { get; set; }
			public string id { get; set; }
			public float? latitude { get; set; }
			public double? cant_book { get; set; }
			public string city_trans { get; set; }
			public double? is_beach_front { get; set; }
			public double? hotel_id { get; set; }
			public Bwallet bwallet { get; set; }
			public double? extended { get; set; }
			public object updated_checkout { get; set; }
			public string type { get; set; }
			public double? property_cribs_availability { get; set; }
			public string hotel_facilities { get; set; }
			public float? min_total_price { get; set; }
			public string zip { get; set; }
			public Distance[] distances { get; set; }
			public double? price_is_final { get; set; }
			public double? ufi { get; set; }
			public string distance { get; set; }
			public string hotel_name_trans { get; set; }
			public string currencycode { get; set; }
			public string countrycode { get; set; }
			public string districts { get; set; }
			public string city { get; set; }
			public string district { get; set; }
			public string hotel_name { get; set; }
			public string max_photo_url { get; set; }
			public string max_1440_photo_url { get; set; }
			public External_Reviews external_reviews { get; set; }
			public string generated_property_title { get; set; }
		}

		public class Composite_Price_Breakdown
		{
			public Gross_Amount_Hotel_Currency gross_amount_hotel_currency { get; set; }
			public Benefit[] benefits { get; set; }
			public All_Inclusive_Amount_Hotel_Currency all_inclusive_amount_hotel_currency { get; set; }
			public All_Inclusive_Amount all_inclusive_amount { get; set; }
			public Product_Price_Breakdowns[] product_price_breakdowns { get; set; }
			public Item1[] items { get; set; }
			public Price_Display_Config1[] price_display_config { get; set; }
			public Gross_Amount gross_amount { get; set; }
			public Charges_Details charges_details { get; set; }
			public Gross_Amount_Per_Night gross_amount_per_night { get; set; }
			public Net_Amount net_amount { get; set; }
			public Included_Taxes_And_Charges_Amount included_taxes_and_charges_amount { get; set; }
			public Excluded_Amount excluded_amount { get; set; }
			public Discounted_Amount discounted_amount { get; set; }
			public Strikethrough_Amount strikethrough_amount { get; set; }
			public Strikethrough_Amount_Per_Night strikethrough_amount_per_night { get; set; }
		}

		public class Gross_Amount_Hotel_Currency
		{
			public string amount_rounded { get; set; }
			public float? value { get; set; }
			public string currency { get; set; }
			public string amount_unrounded { get; set; }
		}

		public class All_Inclusive_Amount_Hotel_Currency
		{
			public float? value { get; set; }
			public string currency { get; set; }
			public string amount_unrounded { get; set; }
			public string amount_rounded { get; set; }
		}

		public class All_Inclusive_Amount
		{
			public string amount_unrounded { get; set; }
			public string currency { get; set; }
			public float? value { get; set; }
			public string amount_rounded { get; set; }
		}

		public class Gross_Amount
		{
			public string amount_rounded { get; set; }
			public string currency { get; set; }
			public float? value { get; set; }
			public string amount_unrounded { get; set; }
		}

		public class Charges_Details
		{
			public string translated_copy { get; set; }
			public string mode { get; set; }
			public Amount amount { get; set; }
		}

		public class Amount
		{
			public double? value { get; set; }
			public string currency { get; set; }
		}

		public class Gross_Amount_Per_Night
		{
			public string amount_rounded { get; set; }
			public string amount_unrounded { get; set; }
			public string currency { get; set; }
			public float? value { get; set; }
		}

		public class Net_Amount
		{
			public string amount_unrounded { get; set; }
			public string currency { get; set; }
			public float? value { get; set; }
			public string amount_rounded { get; set; }
		}

		public class Included_Taxes_And_Charges_Amount
		{
			public string amount_rounded { get; set; }
			public string amount_unrounded { get; set; }
			public string currency { get; set; }
			public float? value { get; set; }
		}

		public class Excluded_Amount
		{
			public string amount_rounded { get; set; }
			public double? value { get; set; }
			public string currency { get; set; }
			public string amount_unrounded { get; set; }
		}

		public class Discounted_Amount
		{
			public string amount_unrounded { get; set; }
			public float? value { get; set; }
			public string currency { get; set; }
			public string amount_rounded { get; set; }
		}

		public class Strikethrough_Amount
		{
			public string amount_unrounded { get; set; }
			public string currency { get; set; }
			public float? value { get; set; }
			public string amount_rounded { get; set; }
		}

		public class Strikethrough_Amount_Per_Night
		{
			public string amount_unrounded { get; set; }
			public string currency { get; set; }
			public float? value { get; set; }
			public string amount_rounded { get; set; }
		}

		public class Benefit
		{
			public string badge_variant { get; set; }
			public string details { get; set; }
			public string identifier { get; set; }
			public string kind { get; set; }
			public string name { get; set; }
			public object icon { get; set; }
		}

		public class Product_Price_Breakdowns
		{
			public Gross_Amount1 gross_amount { get; set; }
			public Charges_Details1 charges_details { get; set; }
			public Price_Display_Config[] price_display_config { get; set; }
			public Item[] items { get; set; }
			public Gross_Amount_Hotel_Currency1 gross_amount_hotel_currency { get; set; }
			public Benefit1[] benefits { get; set; }
			public All_Inclusive_Amount_Hotel_Currency1 all_inclusive_amount_hotel_currency { get; set; }
			public All_Inclusive_Amount1 all_inclusive_amount { get; set; }
			public Excluded_Amount1 excluded_amount { get; set; }
			public Net_Amount1 net_amount { get; set; }
			public Included_Taxes_And_Charges_Amount1 included_taxes_and_charges_amount { get; set; }
			public Gross_Amount_Per_Night1 gross_amount_per_night { get; set; }
			public Discounted_Amount1 discounted_amount { get; set; }
			public Strikethrough_Amount1 strikethrough_amount { get; set; }
			public Strikethrough_Amount_Per_Night1 strikethrough_amount_per_night { get; set; }
		}

		public class Gross_Amount1
		{
			public string amount_rounded { get; set; }
			public string amount_unrounded { get; set; }
			public string currency { get; set; }
			public float? value { get; set; }
		}

		public class Charges_Details1
		{
			public string mode { get; set; }
			public string translated_copy { get; set; }
			public Amount1 amount { get; set; }
		}

		public class Amount1
		{
			public string currency { get; set; }
			public double? value { get; set; }
		}

		public class Gross_Amount_Hotel_Currency1
		{
			public string amount_unrounded { get; set; }
			public float? value { get; set; }
			public string currency { get; set; }
			public string amount_rounded { get; set; }
		}

		public class All_Inclusive_Amount_Hotel_Currency1
		{
			public string amount_rounded { get; set; }
			public string currency { get; set; }
			public float? value { get; set; }
			public string amount_unrounded { get; set; }
		}

		public class All_Inclusive_Amount1
		{
			public string amount_rounded { get; set; }
			public string currency { get; set; }
			public float? value { get; set; }
			public string amount_unrounded { get; set; }
		}

		public class Excluded_Amount1
		{
			public string amount_unrounded { get; set; }
			public string currency { get; set; }
			public double? value { get; set; }
			public string amount_rounded { get; set; }
		}

		public class Net_Amount1
		{
			public string currency { get; set; }
			public float? value { get; set; }
			public string amount_unrounded { get; set; }
			public string amount_rounded { get; set; }
		}

		public class Included_Taxes_And_Charges_Amount1
		{
			public float? value { get; set; }
			public string currency { get; set; }
			public string amount_unrounded { get; set; }
			public string amount_rounded { get; set; }
		}

		public class Gross_Amount_Per_Night1
		{
			public string amount_rounded { get; set; }
			public string amount_unrounded { get; set; }
			public string currency { get; set; }
			public float? value { get; set; }
		}

		public class Discounted_Amount1
		{
			public string amount_unrounded { get; set; }
			public float? value { get; set; }
			public string currency { get; set; }
			public string amount_rounded { get; set; }
		}

		public class Strikethrough_Amount1
		{
			public string amount_unrounded { get; set; }
			public string currency { get; set; }
			public float? value { get; set; }
			public string amount_rounded { get; set; }
		}

		public class Strikethrough_Amount_Per_Night1
		{
			public string amount_rounded { get; set; }
			public string amount_unrounded { get; set; }
			public string currency { get; set; }
			public float? value { get; set; }
		}

		public class Price_Display_Config
		{
			public double? value { get; set; }
			public string key { get; set; }
		}

		public class Item
		{
			public Item_Amount item_amount { get; set; }
			public Base _base { get; set; }
			public string details { get; set; }
			public string inclusion_type { get; set; }
			public string kind { get; set; }
			public string name { get; set; }
			public string identifier { get; set; }
		}

		public class Item_Amount
		{
			public string amount_unrounded { get; set; }
			public string currency { get; set; }
			public float? value { get; set; }
			public string amount_rounded { get; set; }
		}

		public class Base
		{
			public string kind { get; set; }
			public float? base_amount { get; set; }
			public float? percentage { get; set; }
		}

		public class Benefit1
		{
			public string details { get; set; }
			public string badge_variant { get; set; }
			public string identifier { get; set; }
			public string kind { get; set; }
			public string name { get; set; }
			public object icon { get; set; }
		}

		public class Item1
		{
			public string kind { get; set; }
			public string name { get; set; }
			public string inclusion_type { get; set; }
			public Item_Amount1 item_amount { get; set; }
			public Base1 _base { get; set; }
			public string details { get; set; }
			public string identifier { get; set; }
		}

		public class Item_Amount1
		{
			public string amount_rounded { get; set; }
			public float? value { get; set; }
			public string currency { get; set; }
			public string amount_unrounded { get; set; }
		}

		public class Base1
		{
			public string kind { get; set; }
			public float? base_amount { get; set; }
			public float? percentage { get; set; }
		}

		public class Price_Display_Config1
		{
			public string key { get; set; }
			public double? value { get; set; }
		}

		public class Checkin
		{
			public string from { get; set; }
			public string until { get; set; }
		}

		public class Matching_Units_Configuration
		{
			public Matching_Units_Common_Config matching_units_common_config { get; set; }
		}

		public class Matching_Units_Common_Config
		{
			public string localized_area { get; set; }
			public double? unit_type_id { get; set; }
		}

		public class Price_Breakdown
		{
			public string currency { get; set; }
			public double? has_incalculable_charges { get; set; }
			public double? has_tax_exceptions { get; set; }
			public string sum_excluded_raw { get; set; }
			public float? all_inclusive_price { get; set; }
			public object gross_price { get; set; }
			public double? has_fine_print_charges { get; set; }
		}

		public class Booking_Home
		{
			public string group { get; set; }
			public object is_single_unit_property { get; set; }
			public double? is_booking_home { get; set; }
			public double? segment { get; set; }
			public double? quality_class { get; set; }
		}

		public class Checkout
		{
			public string until { get; set; }
			public string from { get; set; }
		}

		public class Bwallet
		{
			public double? hotel_eligibility { get; set; }
		}

		public class External_Reviews
		{
			public float? score { get; set; }
			public string should_display { get; set; }
			public double? num_reviews { get; set; }
			public string score_word { get; set; }
		}

		public class Badge
		{
			public string badge_variant { get; set; }
			public string id { get; set; }
			public string text { get; set; }
		}

		public class Distance
		{
			public string icon_name { get; set; }
			public object icon_set { get; set; }
			public string text { get; set; }
		}

	}
}
