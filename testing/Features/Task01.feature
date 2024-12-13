Feature: Automation QA Tasks

@DataSource:testData/southAfricaData.xlsx 
Scenario: 1. Order First Non Promo Stock
	Given User Navigates to <url>
	When User Clicks on 'accept_all_btn'
	And User Hovers over 'non_promo_product'
	And User Clicks on 'buy_btn'
	Then 'added_notification' should be visible
	When 'added_notification' is not visible
	Then 'basket_menu_btn' should be visible
	Then User Clicks on 'basket_menu_btn'
	And User Clicks on 'goto_payment_btn'
	Then User Enters <email> in 'guest_email_input'
	And User Clicks on 'continue_as_guest_btn'
	Then 'confirm_order_btn' should be visible
	Then User Enters <name> in 'name_input'
	Then User Enters <surname> in 'surname_input'
	Then User Enters <phone> in 'phone_input'
	Then User Enters <country> in 'country_input'
	And User Clicks on 'country_option'
	Then User Enters <city> in 'city_input'
	Then 'city_option' should be visible
	And User Clicks on 'city_option'
	And User Clicks on 'officepargo_option'
	Then User Enters Address1 in 'delivery_office_input'
	And User Clicks on 'delivery_office_option'
	Then 'delivery_cost' should be visible
	And User Clicks on 'confirm_order_btn'
	Then 'thankyou_heading' should be visible

@DataSource:testData/southAfricaData.xlsx 
Scenario: 2. Verify 50% off label is visible
	Given User Navigates to <url>
	When User Clicks on 'accept_all_btn'
	Then '50_percent_promo_label' should be visible
	And '50_percent_promo_product' should be visible