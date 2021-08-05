Задача 1
========
Рекламные площадки
------------------

В текстовом файле перечислены рекламоносители и локации, в которых они действуют.  
Например:

Яндекс.Директ:/ru  
Бегущая строка в троллейбусах Екатеринбурга:/ru/svrd/ekb  
Быстрый курьер:/ru/svrd/ekb  
Ревдинский рабочий:/ru/svrd/revda,/ru/svrd/pervik  
Газета уральских москвичей:/ru/msk,/ru/permobl/,/ru/chelobl  

Рекламоноситель действует во всех своих основных локациях, а также во всех вложенных.  
В указанном примере Яндекс.Директ действует в локациях /ru, /ru/svrd, /ru/svrd/ekb и т.д.  
У одного носителя может быть несколько основных локаций, как у Ревдинского рабочего.  

Задача: вывести все рекламоносители, которые действуют в заданной локации.

Например, рекламоносители, действующие в локации "/ru/svrd/pervik":  
Яндекс.Директ  
Ревдинский рабочий  

На анализ может подаваться локация, которая отсутствует в исходном файле, к примеру "/ru/svrd/ekb/center/square1905".  
Ответ для неё будет таким:  
Яндекс.Директ  
Бегущая строка в троллейбусах Екатеринбурга  
Быстрый курьер  

Входные данные всегда корректны.  
У рекламоносителя не более 4 основных локаций.  
Исходный файл занимает не более 20% доступной памяти.  