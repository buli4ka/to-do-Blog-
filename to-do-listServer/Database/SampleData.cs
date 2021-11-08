using System.Linq;
using to_do_listServer.Models;

namespace to_do_listServer.Database
{
    public class SampleData
    {
        public static void InitData(Context context)
        {
            if (!context.Users.Any())
            {
                context.Users.Add(new User
                {
                    FirstName = "a",
                    LastName = "a",
                    Username = "a",
                    Password = BCrypt.Net.BCrypt.HashPassword("a")
                });
            }

            // if (!context.Users.Any())
            //
            //     context.Posts.AddRange(new Post
            //         {
            //             Title = "Lorem Ipsum",
            //             Text =
            //                 "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus a tortor eu magna molestie blandit pellentesque ut erat. Pellentesque et pharetra dui. Integer ac mi elementum lacus scelerisque porttitor. Morbi ligula libero, efficitur eget lacus vel, lacinia sagittis mi. Sed tristique ultrices augue ac pretium. Mauris rhoncus odio a lacus pellentesque, at pulvinar orci porta. Donec et urna quam. Nam vel turpis et felis euismod ultricies. Vivamus finibus ex eu tellus faucibus convallis. Morbi eu augue dapibus, consequat tortor in, facilisis erat. Donec hendrerit nisi venenatis purus tincidunt, ut lobortis lorem dictum. Nullam viverra elit a turpis porta, at hendrerit urna facilisis. In ut felis auctor, tristique purus commodo, ultrices dolor. Phasellus porta nulla et ex rhoncus porttitor. Quisque iaculis lorem at enim scelerisque, et accumsan justo semper. Nam gravida pharetra dictum. Nunc varius eget mi vel porta. Vivamus ornare tortor sem, a interdum ante congue eu. Donec vehicula justo placerat egestas vehicula. Curabitur vel aliquam felis. Pellentesque lobortis eget dolor ac imperdiet. Phasellus tortor mauris, ultrices eget condimentum id, laoreet id urna. Maecenas eu massa sed quam tempor fermentum et id quam. Nullam vitae dapibus neque. Aliquam porttitor sollicitudin aliquam. Vivamus vulputate tempor arcu nec commodo. In non erat orci. Vivamus in nibh placerat, egestas massa sit amet, hendrerit augue. Nam sed iaculis sapien, non malesuada lectus. Etiam a quam a arcu viverra ullamcorper. Nulla tincidunt risus nec augue porta ultricies. Pellentesque non sapien erat. Curabitur facilisis sapien blandit vulputate dignissim. Donec accumsan dapibus sollicitudin. Sed maximus quam non ligula consequat, sed condimentum est venenatis. Quisque nulla diam, pretium sit amet odio ut, blandit placerat mauris. Donec varius leo ultrices bibendum tempus. Nunc feugiat nibh in nibh hendrerit, id ornare nulla luctus. Suspendisse potenti. Nulla elementum, urna non commodo imperdiet, sapien erat porttitor diam, et blandit turpis massa non sapien. Etiam consequat nibh augue, eu molestie leo auctor ut. In hac habitasse platea dictumst. Nullam ut purus eget ipsum porttitor fringilla et id ipsum. Vestibulum mollis magna a nulla fringilla auctor. Nunc in purus eget augue commodo tincidunt. Maecenas eu finibus dui. Nam in diam faucibus mauris bibendum feugiat. Donec lobortis nibh at ipsum condimentum tempor. Pellentesque turpis risus, iaculis non enim nec, molestie gravida quam. Suspendisse nec nibh quis ex lacinia sagittis. Fusce dictum libero quam, non molestie diam luctus a. Suspendisse sed posuere nulla. Sed rhoncus semper dignissim. Mauris congue elementum nunc volutpat tristique. Sed porta euismod nisl vel ornare. Donec aliquet blandit tellus sit amet consequat. Vivamus tempor arcu ex, nec rutrum eros tristique at. Maecenas placerat quam eget justo scelerisque, vel imperdiet justo ullamcorper. Nullam tincidunt ultrices ipsum nec accumsan. Aliquam ut scelerisque ipsum, eu placerat tortor. Quisque commodo sed lectus eget fringilla. Interdum et malesuada fames ac ante ipsum primis in faucibus. Ut ornare tellus ante, a vehicula dolor interdum id. Donec non tempus justo. Etiam auctor quis purus non bibendum. Vestibulum lacus libero, ultrices id laoreet vitae, vehicula quis lorem. Cras faucibus, risus vel semper accumsan, nisi est posuere enim, quis finibus augue neque nec velit. Sed imperdiet felis orci, nec molestie nulla malesuada vel. Etiam non lorem magna. Aliquam hendrerit mi a orci pharetra, et pretium diam posuere. In hac habitasse platea dictumst. Phasellus ex purus, semper non lorem non, maximus facilisis arcu. Fusce sit amet tellus imperdiet, molestie mauris ut, aliquet neque. Nullam ornare odio eu velit mollis, a dignissim metus tristique. Aliquam malesuada massa vehicula sollicitudin finibus. Curabitur ligula tellus, rutrum maximus eros quis, placerat sagittis sem. Ut blandit iaculis nunc, sed pellentesque turpis auctor sed. Donec nulla ante, tincidunt non nisi quis, volutpat ullamcorper nibh. Morbi blandit a massa sed dapibus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Duis id leo ut justo ultricies malesuada vitae sit amet ex. Nam commodo blandit massa, sit amet sollicitudin sapien. Vivamus eget tortor sed ex eleifend mollis ac vitae turpis. Ut sed sodales enim. Suspendisse consequat libero ac magna vulputate sollicitudin at non nulla. Nunc sagittis metus a dolor pharetra pulvinar. Donec mi tellus, condimentum sit amet efficitur ac, consectetur non tortor. Cras dapibus, dolor cursus feugiat tincidunt, est elit volutpat purus, sed venenatis ligula tortor eu massa. Nullam pharetra, purus id vehicula pharetra, neque erat semper elit, ut volutpat leo turpis a lectus. Praesent sollicitudin libero sit amet purus euismod volutpat. Duis tempor commodo leo et blandit. Fusce mollis massa ac augue elementum, in ultrices eros finibus. Phasellus sed est convallis, auctor ante a, tempor sem. Phasellus purus lacus, condimentum nec lorem ac, mattis pharetra tellus. Nam ipsum ligula, malesuada eu dictum et, rhoncus pulvinar magna. Vivamus tortor arcu, elementum quis sem et, ullamcorper volutpat ex. Donec quis leo et dui convallis porttitor id a urna. Vivamus leo justo, faucibus tempor congue et, venenatis finibus justo. Praesent ac libero nec libero porttitor ullamcorper. Nam accumsan metus vitae metus placerat, eget consectetur tellus consectetur. Pellentesque eu magna quis quam maximus sodales et vel magna. Nunc maximus sodales turpis, in vestibulum elit. Phasellus dapibus, orci vel tristique tempor, dolor dui mattis urna, eget ullamcorper est eros sed elit. Cras vestibulum, odio non tempor aliquam, libero felis dignissim sem, in blandit felis turpis eu leo. Curabitur egestas tempor eleifend. Phasellus ornare, elit eu mattis maximus, nunc sem interdum nulla, at ornare libero felis vel lorem. Integer bibendum hendrerit lorem quis rhoncus. Duis tristique nec metus a dictum. Suspendisse potenti. Phasellus venenatis viverra porttitor. Nunc id finibus ante, a mollis urna. In dictum vehicula libero, vel rutrum quam venenatis feugiat. Phasellus at ante odio. Donec lacinia urna lacus, ac vulputate enim scelerisque sit amet. Praesent elit urna, varius sit amet sodales eget, rhoncus ac est. Integer luctus nunc vitae nisl posuere ultricies. Curabitur ac tincidunt tellus. In fermentum diam tortor, at consequat purus efficitur at. Nam in lacinia ipsum. Sed ultrices, nisi vel fringilla efficitur, mauris ipsum commodo ligula, a fringilla libero ante vitae orci. Nunc non quam a purus rutrum rhoncus ac condimentum arcu. Curabitur ligula justo, bibendum tincidunt ultrices vitae, consequat vel nulla. In ultricies nulla vel rutrum sagittis. Proin nec blandit nunc. Nunc vitae vulputate ex, sit amet consequat nibh. Quisque est lectus, hendrerit vel pulvinar id, euismod ut est. Aenean mauris enim, vulputate vitae odio eget, vulputate vestibulum erat. Ut diam orci, malesuada eu volutpat at, ornare eget dui. Curabitur laoreet elit neque, at sollicitudin nunc elementum in. Pellentesque laoreet lacus eu enim ultrices, non sollicitudin quam varius. Curabitur scelerisque mauris vitae placerat molestie. Morbi a tortor quis elit eleifend pulvinar at egestas nisi. Vivamus quis purus velit. Morbi sit amet lectus ut lectus malesuada tincidunt. Sed sagittis pretium aliquam. Proin dapibus lorem lacus, ut sagittis libero ullamcorper nec. Fusce quis tempus urna, non tempus turpis. Phasellus massa quam, placerat id semper tincidunt, pellentesque sit amet augue. Praesent vitae orci tristique, fringilla est nec, sagittis nisl. Integer sed justo velit. Sed bibendum, urna eget placerat suscipit, leo odio pretium nibh, quis efficitur ipsum diam in nunc.",
            //             Author = new User
            //             {
            //                 FirstName = "Andrew",
            //                 LastName = "Andrew",
            //                 Username = "Andrew",
            //                 Password = BCrypt.Net.BCrypt.HashPassword("a")
            //             },
            //         }, new Post
            //         {
            //             Title = "Lorem Ipsum",
            //             Text =
            //                 "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus a tortor eu magna molestie blandit pellentesque ut erat. Pellentesque et pharetra dui. Integer ac mi elementum lacus scelerisque porttitor. Morbi ligula libero, efficitur eget lacus vel, lacinia sagittis mi. Sed tristique ultrices augue ac pretium. Mauris rhoncus odio a lacus pellentesque, at pulvinar orci porta. Donec et urna quam. Nam vel turpis et felis euismod ultricies. Vivamus finibus ex eu tellus faucibus convallis. Morbi eu augue dapibus, consequat tortor in, facilisis erat. Donec hendrerit nisi venenatis purus tincidunt, ut lobortis lorem dictum. Nullam viverra elit a turpis porta, at hendrerit urna facilisis. In ut felis auctor, tristique purus commodo, ultrices dolor. Phasellus porta nulla et ex rhoncus porttitor. Quisque iaculis lorem at enim scelerisque, et accumsan justo semper. Nam gravida pharetra dictum. Nunc varius eget mi vel porta. Vivamus ornare tortor sem, a interdum ante congue eu. Donec vehicula justo placerat egestas vehicula. Curabitur vel aliquam felis. Pellentesque lobortis eget dolor ac imperdiet. Phasellus tortor mauris, ultrices eget condimentum id, laoreet id urna. Maecenas eu massa sed quam tempor fermentum et id quam. Nullam vitae dapibus neque. Aliquam porttitor sollicitudin aliquam. Vivamus vulputate tempor arcu nec commodo. In non erat orci. Vivamus in nibh placerat, egestas massa sit amet, hendrerit augue. Nam sed iaculis sapien, non malesuada lectus. Etiam a quam a arcu viverra ullamcorper. Nulla tincidunt risus nec augue porta ultricies. Pellentesque non sapien erat. Curabitur facilisis sapien blandit vulputate dignissim. Donec accumsan dapibus sollicitudin. Sed maximus quam non ligula consequat, sed condimentum est venenatis. Quisque nulla diam, pretium sit amet odio ut, blandit placerat mauris. Donec varius leo ultrices bibendum tempus. Nunc feugiat nibh in nibh hendrerit, id ornare nulla luctus. Suspendisse potenti. Nulla elementum, urna non commodo imperdiet, sapien erat porttitor diam, et blandit turpis massa non sapien. Etiam consequat nibh augue, eu molestie leo auctor ut. In hac habitasse platea dictumst. Nullam ut purus eget ipsum porttitor fringilla et id ipsum. Vestibulum mollis magna a nulla fringilla auctor. Nunc in purus eget augue commodo tincidunt. Maecenas eu finibus dui. Nam in diam faucibus mauris bibendum feugiat. Donec lobortis nibh at ipsum condimentum tempor. Pellentesque turpis risus, iaculis non enim nec, molestie gravida quam. Suspendisse nec nibh quis ex lacinia sagittis. Fusce dictum libero quam, non molestie diam luctus a. Suspendisse sed posuere nulla. Sed rhoncus semper dignissim. Mauris congue elementum nunc volutpat tristique. Sed porta euismod nisl vel ornare. Donec aliquet blandit tellus sit amet consequat. Vivamus tempor arcu ex, nec rutrum eros tristique at. Maecenas placerat quam eget justo scelerisque, vel imperdiet justo ullamcorper. Nullam tincidunt ultrices ipsum nec accumsan. Aliquam ut scelerisque ipsum, eu placerat tortor. Quisque commodo sed lectus eget fringilla. Interdum et malesuada fames ac ante ipsum primis in faucibus. Ut ornare tellus ante, a vehicula dolor interdum id. Donec non tempus justo. Etiam auctor quis purus non bibendum. Vestibulum lacus libero, ultrices id laoreet vitae, vehicula quis lorem. Cras faucibus, risus vel semper accumsan, nisi est posuere enim, quis finibus augue neque nec velit. Sed imperdiet felis orci, nec molestie nulla malesuada vel. Etiam non lorem magna. Aliquam hendrerit mi a orci pharetra, et pretium diam posuere. In hac habitasse platea dictumst. Phasellus ex purus, semper non lorem non, maximus facilisis arcu. Fusce sit amet tellus imperdiet, molestie mauris ut, aliquet neque. Nullam ornare odio eu velit mollis, a dignissim metus tristique. Aliquam malesuada massa vehicula sollicitudin finibus. Curabitur ligula tellus, rutrum maximus eros quis, placerat sagittis sem. Ut blandit iaculis nunc, sed pellentesque turpis auctor sed. Donec nulla ante, tincidunt non nisi quis, volutpat ullamcorper nibh. Morbi blandit a massa sed dapibus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Duis id leo ut justo ultricies malesuada vitae sit amet ex. Nam commodo blandit massa, sit amet sollicitudin sapien. Vivamus eget tortor sed ex eleifend mollis ac vitae turpis. Ut sed sodales enim. Suspendisse consequat libero ac magna vulputate sollicitudin at non nulla. Nunc sagittis metus a dolor pharetra pulvinar. Donec mi tellus, condimentum sit amet efficitur ac, consectetur non tortor. Cras dapibus, dolor cursus feugiat tincidunt, est elit volutpat purus, sed venenatis ligula tortor eu massa. Nullam pharetra, purus id vehicula pharetra, neque erat semper elit, ut volutpat leo turpis a lectus. Praesent sollicitudin libero sit amet purus euismod volutpat. Duis tempor commodo leo et blandit. Fusce mollis massa ac augue elementum, in ultrices eros finibus. Phasellus sed est convallis, auctor ante a, tempor sem. Phasellus purus lacus, condimentum nec lorem ac, mattis pharetra tellus. Nam ipsum ligula, malesuada eu dictum et, rhoncus pulvinar magna. Vivamus tortor arcu, elementum quis sem et, ullamcorper volutpat ex. Donec quis leo et dui convallis porttitor id a urna. Vivamus leo justo, faucibus tempor congue et, venenatis finibus justo. Praesent ac libero nec libero porttitor ullamcorper. Nam accumsan metus vitae metus placerat, eget consectetur tellus consectetur. Pellentesque eu magna quis quam maximus sodales et vel magna. Nunc maximus sodales turpis, in vestibulum elit. Phasellus dapibus, orci vel tristique tempor, dolor dui mattis urna, eget ullamcorper est eros sed elit. Cras vestibulum, odio non tempor aliquam, libero felis dignissim sem, in blandit felis turpis eu leo. Curabitur egestas tempor eleifend. Phasellus ornare, elit eu mattis maximus, nunc sem interdum nulla, at ornare libero felis vel lorem. Integer bibendum hendrerit lorem quis rhoncus. Duis tristique nec metus a dictum. Suspendisse potenti. Phasellus venenatis viverra porttitor. Nunc id finibus ante, a mollis urna. In dictum vehicula libero, vel rutrum quam venenatis feugiat. Phasellus at ante odio. Donec lacinia urna lacus, ac vulputate enim scelerisque sit amet. Praesent elit urna, varius sit amet sodales eget, rhoncus ac est. Integer luctus nunc vitae nisl posuere ultricies. Curabitur ac tincidunt tellus. In fermentum diam tortor, at consequat purus efficitur at. Nam in lacinia ipsum. Sed ultrices, nisi vel fringilla efficitur, mauris ipsum commodo ligula, a fringilla libero ante vitae orci. Nunc non quam a purus rutrum rhoncus ac condimentum arcu. Curabitur ligula justo, bibendum tincidunt ultrices vitae, consequat vel nulla. In ultricies nulla vel rutrum sagittis. Proin nec blandit nunc. Nunc vitae vulputate ex, sit amet consequat nibh. Quisque est lectus, hendrerit vel pulvinar id, euismod ut est. Aenean mauris enim, vulputate vitae odio eget, vulputate vestibulum erat. Ut diam orci, malesuada eu volutpat at, ornare eget dui. Curabitur laoreet elit neque, at sollicitudin nunc elementum in. Pellentesque laoreet lacus eu enim ultrices, non sollicitudin quam varius. Curabitur scelerisque mauris vitae placerat molestie. Morbi a tortor quis elit eleifend pulvinar at egestas nisi. Vivamus quis purus velit. Morbi sit amet lectus ut lectus malesuada tincidunt. Sed sagittis pretium aliquam. Proin dapibus lorem lacus, ut sagittis libero ullamcorper nec. Fusce quis tempus urna, non tempus turpis. Phasellus massa quam, placerat id semper tincidunt, pellentesque sit amet augue. Praesent vitae orci tristique, fringilla est nec, sagittis nisl. Integer sed justo velit. Sed bibendum, urna eget placerat suscipit, leo odio pretium nibh, quis efficitur ipsum diam in nunc.",
            //             Author = new User
            //             {
            //                 FirstName = "Vlad",
            //                 LastName = "Vlad",
            //                 Username = "Vlad",
            //                 Password = BCrypt.Net.BCrypt.HashPassword("q")
            //             },
            //         }, new Post
            //         {
            //             Title = "Lorem Ipsum",
            //             Text =
            //                 "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus a tortor eu magna molestie blandit pellentesque ut erat. Pellentesque et pharetra dui. Integer ac mi elementum lacus scelerisque porttitor. Morbi ligula libero, efficitur eget lacus vel, lacinia sagittis mi. Sed tristique ultrices augue ac pretium. Mauris rhoncus odio a lacus pellentesque, at pulvinar orci porta. Donec et urna quam. Nam vel turpis et felis euismod ultricies. Vivamus finibus ex eu tellus faucibus convallis. Morbi eu augue dapibus, consequat tortor in, facilisis erat. Donec hendrerit nisi venenatis purus tincidunt, ut lobortis lorem dictum. Nullam viverra elit a turpis porta, at hendrerit urna facilisis. In ut felis auctor, tristique purus commodo, ultrices dolor. Phasellus porta nulla et ex rhoncus porttitor. Quisque iaculis lorem at enim scelerisque, et accumsan justo semper. Nam gravida pharetra dictum. Nunc varius eget mi vel porta. Vivamus ornare tortor sem, a interdum ante congue eu. Donec vehicula justo placerat egestas vehicula. Curabitur vel aliquam felis. Pellentesque lobortis eget dolor ac imperdiet. Phasellus tortor mauris, ultrices eget condimentum id, laoreet id urna. Maecenas eu massa sed quam tempor fermentum et id quam. Nullam vitae dapibus neque. Aliquam porttitor sollicitudin aliquam. Vivamus vulputate tempor arcu nec commodo. In non erat orci. Vivamus in nibh placerat, egestas massa sit amet, hendrerit augue. Nam sed iaculis sapien, non malesuada lectus. Etiam a quam a arcu viverra ullamcorper. Nulla tincidunt risus nec augue porta ultricies. Pellentesque non sapien erat. Curabitur facilisis sapien blandit vulputate dignissim. Donec accumsan dapibus sollicitudin. Sed maximus quam non ligula consequat, sed condimentum est venenatis. Quisque nulla diam, pretium sit amet odio ut, blandit placerat mauris. Donec varius leo ultrices bibendum tempus. Nunc feugiat nibh in nibh hendrerit, id ornare nulla luctus. Suspendisse potenti. Nulla elementum, urna non commodo imperdiet, sapien erat porttitor diam, et blandit turpis massa non sapien. Etiam consequat nibh augue, eu molestie leo auctor ut. In hac habitasse platea dictumst. Nullam ut purus eget ipsum porttitor fringilla et id ipsum. Vestibulum mollis magna a nulla fringilla auctor. Nunc in purus eget augue commodo tincidunt. Maecenas eu finibus dui. Nam in diam faucibus mauris bibendum feugiat. Donec lobortis nibh at ipsum condimentum tempor. Pellentesque turpis risus, iaculis non enim nec, molestie gravida quam. Suspendisse nec nibh quis ex lacinia sagittis. Fusce dictum libero quam, non molestie diam luctus a. Suspendisse sed posuere nulla. Sed rhoncus semper dignissim. Mauris congue elementum nunc volutpat tristique. Sed porta euismod nisl vel ornare. Donec aliquet blandit tellus sit amet consequat. Vivamus tempor arcu ex, nec rutrum eros tristique at. Maecenas placerat quam eget justo scelerisque, vel imperdiet justo ullamcorper. Nullam tincidunt ultrices ipsum nec accumsan. Aliquam ut scelerisque ipsum, eu placerat tortor. Quisque commodo sed lectus eget fringilla. Interdum et malesuada fames ac ante ipsum primis in faucibus. Ut ornare tellus ante, a vehicula dolor interdum id. Donec non tempus justo. Etiam auctor quis purus non bibendum. Vestibulum lacus libero, ultrices id laoreet vitae, vehicula quis lorem. Cras faucibus, risus vel semper accumsan, nisi est posuere enim, quis finibus augue neque nec velit. Sed imperdiet felis orci, nec molestie nulla malesuada vel. Etiam non lorem magna. Aliquam hendrerit mi a orci pharetra, et pretium diam posuere. In hac habitasse platea dictumst. Phasellus ex purus, semper non lorem non, maximus facilisis arcu. Fusce sit amet tellus imperdiet, molestie mauris ut, aliquet neque. Nullam ornare odio eu velit mollis, a dignissim metus tristique. Aliquam malesuada massa vehicula sollicitudin finibus. Curabitur ligula tellus, rutrum maximus eros quis, placerat sagittis sem. Ut blandit iaculis nunc, sed pellentesque turpis auctor sed. Donec nulla ante, tincidunt non nisi quis, volutpat ullamcorper nibh. Morbi blandit a massa sed dapibus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Duis id leo ut justo ultricies malesuada vitae sit amet ex. Nam commodo blandit massa, sit amet sollicitudin sapien. Vivamus eget tortor sed ex eleifend mollis ac vitae turpis. Ut sed sodales enim. Suspendisse consequat libero ac magna vulputate sollicitudin at non nulla. Nunc sagittis metus a dolor pharetra pulvinar. Donec mi tellus, condimentum sit amet efficitur ac, consectetur non tortor. Cras dapibus, dolor cursus feugiat tincidunt, est elit volutpat purus, sed venenatis ligula tortor eu massa. Nullam pharetra, purus id vehicula pharetra, neque erat semper elit, ut volutpat leo turpis a lectus. Praesent sollicitudin libero sit amet purus euismod volutpat. Duis tempor commodo leo et blandit. Fusce mollis massa ac augue elementum, in ultrices eros finibus. Phasellus sed est convallis, auctor ante a, tempor sem. Phasellus purus lacus, condimentum nec lorem ac, mattis pharetra tellus. Nam ipsum ligula, malesuada eu dictum et, rhoncus pulvinar magna. Vivamus tortor arcu, elementum quis sem et, ullamcorper volutpat ex. Donec quis leo et dui convallis porttitor id a urna. Vivamus leo justo, faucibus tempor congue et, venenatis finibus justo. Praesent ac libero nec libero porttitor ullamcorper. Nam accumsan metus vitae metus placerat, eget consectetur tellus consectetur. Pellentesque eu magna quis quam maximus sodales et vel magna. Nunc maximus sodales turpis, in vestibulum elit. Phasellus dapibus, orci vel tristique tempor, dolor dui mattis urna, eget ullamcorper est eros sed elit. Cras vestibulum, odio non tempor aliquam, libero felis dignissim sem, in blandit felis turpis eu leo. Curabitur egestas tempor eleifend. Phasellus ornare, elit eu mattis maximus, nunc sem interdum nulla, at ornare libero felis vel lorem. Integer bibendum hendrerit lorem quis rhoncus. Duis tristique nec metus a dictum. Suspendisse potenti. Phasellus venenatis viverra porttitor. Nunc id finibus ante, a mollis urna. In dictum vehicula libero, vel rutrum quam venenatis feugiat. Phasellus at ante odio. Donec lacinia urna lacus, ac vulputate enim scelerisque sit amet. Praesent elit urna, varius sit amet sodales eget, rhoncus ac est. Integer luctus nunc vitae nisl posuere ultricies. Curabitur ac tincidunt tellus. In fermentum diam tortor, at consequat purus efficitur at. Nam in lacinia ipsum. Sed ultrices, nisi vel fringilla efficitur, mauris ipsum commodo ligula, a fringilla libero ante vitae orci. Nunc non quam a purus rutrum rhoncus ac condimentum arcu. Curabitur ligula justo, bibendum tincidunt ultrices vitae, consequat vel nulla. In ultricies nulla vel rutrum sagittis. Proin nec blandit nunc. Nunc vitae vulputate ex, sit amet consequat nibh. Quisque est lectus, hendrerit vel pulvinar id, euismod ut est. Aenean mauris enim, vulputate vitae odio eget, vulputate vestibulum erat. Ut diam orci, malesuada eu volutpat at, ornare eget dui. Curabitur laoreet elit neque, at sollicitudin nunc elementum in. Pellentesque laoreet lacus eu enim ultrices, non sollicitudin quam varius. Curabitur scelerisque mauris vitae placerat molestie. Morbi a tortor quis elit eleifend pulvinar at egestas nisi. Vivamus quis purus velit. Morbi sit amet lectus ut lectus malesuada tincidunt. Sed sagittis pretium aliquam. Proin dapibus lorem lacus, ut sagittis libero ullamcorper nec. Fusce quis tempus urna, non tempus turpis. Phasellus massa quam, placerat id semper tincidunt, pellentesque sit amet augue. Praesent vitae orci tristique, fringilla est nec, sagittis nisl. Integer sed justo velit. Sed bibendum, urna eget placerat suscipit, leo odio pretium nibh, quis efficitur ipsum diam in nunc.",
            //             Author = new User
            //             {
            //                 FirstName = "John",
            //                 LastName = "John",
            //                 Username = "John",
            //                 Password = BCrypt.Net.BCrypt.HashPassword("q")
            //             },
            //         }
            //     );
            context.SaveChanges();
        }
    }
}