Лабораторная работа №1 (SOAP-сервис).

Созданы 2 WCF приложения и один консольный клиент.

Идея: сервис для доставки машины из-за границы, рассчитывает таможенную пошлину, дату доставки и полную итоговую стоимость, с учетом работы доставки, выводит всю информацию о заказе при указанном номере заказа.

WCF приложение - CarService: для создания заказа пользователем и получения ответа. 
WCF приложение - DataService: используется приложением CarService - для манипуляций данными (xml).

ConsoleCli - консольный клиент, где показан пример создания заказа и вывода уже имеющегося заказа.

Сервисы были размещены на localhost IIS, запускались в отдельном пуле "WebService".

