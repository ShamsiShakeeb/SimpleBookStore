Ë
PC:\Users\BS01389\source\repos\SimpleBookStore\SimpleBookStore\WeatherForecast.cs
	namespace 	
SimpleBookStore
 
{ 
public 

class 
WeatherForecast  
{ 
public 
DateOnly 
Date 
{ 
get "
;" #
set$ '
;' (
}) *
public 
int 
TemperatureC 
{  !
get" %
;% &
set' *
;* +
}, -
public		 
int		 
TemperatureF		 
=>		  "
$num		# %
+		& '
(		( )
int		) ,
)		, -
(		- .
TemperatureC		. :
/		; <
$num		= C
)		C D
;		D E
public 
string 
? 
Summary 
{  
get! $
;$ %
set& )
;) *
}+ ,
} 
} î
gC:\Users\BS01389\source\repos\SimpleBookStore\SimpleBookStore\QueryService\Report\ReportQueryService.cs
	namespace 	
SimpleBookStore
 
. 
QueryService &
.& '
Report' -
{ 
public 

class 
ReportQueryService #
:$ %
IReportQueryService& 9
{		 
private

 
readonly

 
IMediaTr

 !
<

! "&
GetCommentCountByUserQuery

" <
,

< =
Task

> B
<

B C
ResponseModel

C P
<

P Q
List

Q U
<

U V$
CommentCountByUserReport

V n
>

n o
>

o p
>

p q
>

q r#
_getCommentCountByUser	

s â
;


â ä
private 
readonly 
IMediaTr !
<! "!
GetUserBookStatsQuery" 7
,7 8
Task9 =
<= >
ResponseModel> K
<K L
ListL P
<P Q
UserBookStatsReportQ d
>d e
>e f
>f g
>g h
_getUserBookStati y
;y z
public 
ReportQueryService !
(! "
IMediaTr" *
<* +&
GetCommentCountByUserQuery+ E
,E F
TaskG K
<K L
ResponseModelL Y
<Y Z
ListZ ^
<^ _$
CommentCountByUserReport_ w
>w x
>x y
>y z
>z {"
getCommentCountByUser	| ë
,
ë í
IMediaTr 
< !
GetUserBookStatsQuery *
,* +
Task, 0
<0 1
ResponseModel1 >
<> ?
List? C
<C D
UserBookStatsReportD W
>W X
>X Y
>Y Z
>Z [
getUserBookStat\ k
)k l
{ 	"
_getCommentCountByUser "
=# $!
getCommentCountByUser% :
;: ;
_getUserBookStat 
= 
getUserBookStat .
;. /
} 	
public 
async 
Task 
< 
ResponseModel '
<' (
List( ,
<, -$
CommentCountByUserReport- E
>E F
>F G
>G H$
CommentCountByUsersAsyncI a
(a b
)b c
{ 	
return 
await "
_getCommentCountByUser /
./ 0
Send0 4
(4 5
)5 6
;6 7
} 	
public 
async 
Task 
< 
ResponseModel '
<' (
List( ,
<, -
UserBookStatsReport- @
>@ A
>A B
>B C
UserBookStatsAsyncD V
(V W
)W X
{ 	
return 
await 
_getUserBookStat )
.) *
Send* .
(. /
)/ 0
;0 1
} 	
} 
} Ö
hC:\Users\BS01389\source\repos\SimpleBookStore\SimpleBookStore\QueryService\Report\IReportQueryService.cs
	namespace 	
SimpleBookStore
 
. 
QueryService &
.& '
Report' -
{ 
public 

	interface 
IReportQueryService (
{ 
Task 
< 
ResponseModel 
< 
List 
<  $
CommentCountByUserReport  8
>8 9
>9 :
>: ;$
CommentCountByUsersAsync< T
(T U
)U V
;V W
Task		 
<		 
ResponseModel		 
<		 
List		 
<		  
UserBookStatsReport		  3
>		3 4
>		4 5
>		5 6
UserBookStatsAsync		7 I
(		I J
)		J K
;		K L
}

 
} €
dC:\Users\BS01389\source\repos\SimpleBookStore\SimpleBookStore\QueryService\Book\IBookQueryService.cs
	namespace 	
SimpleBookStore
 
. 
QueryService &
.& '
Book' +
{ 
public 

	interface 
IBookQueryService &
{ 
Task 
< #
PaginationResponseModel $
<$ %
BookResponseModel% 6
>6 7
>7 8
BookListAsync9 F
(F G
intG J
pageSizeK S
,S T
intU X
	pageIndexY b
)b c
;c d
Task		 
<		 #
PaginationResponseModel		 $
<		$ %!
BookInfoResponseModel		% :
>		: ;
>		; <
BookDetailsAsync		= M
(		M N
int		N Q
pageSize		R Z
,		Z [
int		\ _
	pageIndex		` i
)		i j
;		j k
}

 
} ë
cC:\Users\BS01389\source\repos\SimpleBookStore\SimpleBookStore\QueryService\Book\BookQueryService.cs
	namespace 	
SimpleBookStore
 
. 
QueryService &
.& '
Book' +
{ 
public 

class 
BookQueryService !
:" #
IBookQueryService$ 5
{		 
private

 
readonly

 
IMediaTr

 !
<

! "
GetBookListQuery

" 2
,

2 3
Task

4 8
<

8 9#
PaginationResponseModel

9 P
<

P Q
BookResponseModel

Q b
>

b c
>

c d
>

d e
	_bookList

f o
;

o p
private 
readonly 
IMediaTr !
<! ""
GetBookDetailInfoQuery" 8
,8 9
Task: >
<> ?#
PaginationResponseModel? V
<V W!
BookInfoResponseModelW l
>l m
>m n
>n o
_bookDetailsp |
;| }
public 
BookQueryService 
(  
IMediaTr  (
<( )
GetBookListQuery) 9
,9 :
Task; ?
<? @#
PaginationResponseModel@ W
<W X
BookResponseModelX i
>i j
>j k
>k l
bookListm u
,u v
IMediaTr 
< "
GetBookDetailInfoQuery +
,+ ,
Task- 1
<1 2#
PaginationResponseModel2 I
<I J!
BookInfoResponseModelJ _
>_ `
>` a
>a b
bookDetailsc n
)n o
{ 	
	_bookList 
= 
bookList  
;  !
_bookDetails 
= 
bookDetails &
;& '
} 	
public 
async 
Task 
< #
PaginationResponseModel 1
<1 2
BookResponseModel2 C
>C D
>D E
BookListAsyncF S
(S T
intT W
pageSizeX `
,` a
intb e
	pageIndexf o
)o p
{ 	
return 
await 
	_bookList "
." #
Send# '
(' (
new( +
object, 2
[2 3
]3 4
{5 6
pageSize7 ?
,? @
	pageIndexA J
}K L
)L M
;M N
} 	
public 
async 
Task 
< #
PaginationResponseModel 1
<1 2!
BookInfoResponseModel2 G
>G H
>H I
BookDetailsAsyncJ Z
(Z [
int[ ^
pageSize_ g
,g h
inti l
	pageIndexm v
)v w
{ 	
return 
await 
_bookDetails %
.% &
Send& *
(* +
new+ .
object/ 5
[5 6
]6 7
{8 9
pageSize: B
,B C
	pageIndexD M
}N O
)O P
;P Q
} 	
} 
} Ì 
HC:\Users\BS01389\source\repos\SimpleBookStore\SimpleBookStore\Program.cs
var 
builder 
= 
WebApplication 
. 
CreateBuilder *
(* +
args+ /
)/ 0
;0 1
builder 
. 
Services 
. 
AddControllers 
(  
)  !
;! "
builder 
. 
Services 
. #
AddEndpointsApiExplorer (
(( )
)) *
;* +
builder 
. 
Services 
. 
DAL 
( 
) 
; 
builder 
. 
Services 
. 
CQ 
( 
) 
; 
builder 
. 
Services 
. 
	AddScoped 
< 
IBookQueryService ,
,, -
BookQueryService- =
>= >
(> ?
)? @
;@ A
builder 
. 
Services 
. 
	AddScoped 
< 
IReportQueryService .
,. /
ReportQueryService/ A
>A B
(B C
)C D
;D E
builder 
. 
Services 
. 
AddSwaggerGen 
( 
c  
=>! #
{ 
c 
. 

SwaggerDoc 
( 
$str 
, 
new 
OpenApiInfo &
{' (
Title) .
=/ 0
$str1 9
,9 :
Version; B
=C D
$strE I
}J K
)K L
;L M
c 
. !
AddSecurityDefinition 
( 
$str (
,( )
new* -!
OpenApiSecurityScheme. C
{ 
Description 
= 
$str R
,R S
Name 
= 
$str 
, 
In 

= 
ParameterLocation 
. 
Header %
,% &
Type 
= 
SecuritySchemeType !
.! "
ApiKey" (
,( )
Scheme 
= 
$str 
} 
) 
; 
c   
.   "
AddSecurityRequirement   
(   
new    &
OpenApiSecurityRequirement  ! ;
{!! 
{"" 	
new## !
OpenApiSecurityScheme## %
{$$ 
	Reference%% 
=%% 
new%% 
OpenApiReference%%  0
{&& 
Type'' 
='' 
ReferenceType'' (
.''( )
SecurityScheme'') 7
,''7 8
Id(( 
=(( 
$str(( %
})) 
}** 
,** 
Array++ 
.++ 
Empty++ 
<++ 
string++ 
>++ 
(++  
)++  !
},, 	
}-- 
)-- 
;-- 
}.. 
).. 
;.. 
var00 
app00 
=00 	
builder00
 
.00 
Build00 
(00 
)00 
;00 
if33 
(33 
app33 
.33 
Environment33 
.33 
IsDevelopment33 !
(33! "
)33" #
)33# $
{44 
app55 
.55 

UseSwagger55 
(55 
)55 
;55 
app66 
.66 
UseSwaggerUI66 
(66 
)66 
;66 
}77 
app99 
.99 
UseHttpsRedirection99 
(99 
)99 
;99 
app;; 
.;; 
UseAuthorization;; 
(;; 
);; 
;;; 
app== 
.== 
MapControllers== 
(== 
)== 
;== 
await?? 
app?? 	
.??	 

RunAsync??
 
(?? 
)?? 
;?? Í1
dC:\Users\BS01389\source\repos\SimpleBookStore\SimpleBookStore\CustomFiltering\AuthorizationFilter.cs
	namespace		 	
SimpleBookStore		
 
.		 
CustomFiltering		 )
{

 
[ 
AttributeUsage 
( 
validOn 
: 
AttributeTargets -
.- .
Class. 3
|4 5
AttributeTargets6 F
.F G
MethodG M
|N O
SystemP V
.V W
AttributeTargetsW g
.g h
Classh m
,m n
AllowMultipleo |
=} ~
true	 É
)
É Ñ
]
Ñ Ö
public 

class (
AuthorizationFilterAttribute -
:. /
	Attribute0 9
,9 :
IAsyncActionFilter; M
{ 
private 
readonly 
string 
roles  %
;% &
public (
AuthorizationFilterAttribute +
(+ ,
string, 2
roles3 8
)8 9
{ 	
this 
. 
roles 
= 
roles 
; 
} 	
public 
async 
Task "
OnActionExecutionAsync 0
(0 1"
ActionExecutingContext1 G
contextH O
,O P#
ActionExecutionDelegateQ h
nexti m
)m n
{ 	
var 
token 
= 
context 
.  
HttpContext  +
.+ ,
Request, 3
.3 4
Headers4 ;
[; <
HeaderNames< G
.G H
AuthorizationH U
]U V
.V W
ToStringW _
(_ `
)` a
.a b
Replaceb i
(i j
$strj s
,s t
$stru w
)w x
;x y
var 
tokenHandler 
= 
new "#
JwtSecurityTokenHandler# :
(: ;
); <
;< =
var 
key 
= 
Encoding 
. 
ASCII $
.$ %
GetBytes% -
(- .
JwtDescription. <
.< =
Key= @
)@ A
;A B
try 
{ 
tokenHandler 
. 
ValidateToken *
(* +
token+ 0
,0 1
new2 5%
TokenValidationParameters6 O
{ $
ValidateIssuerSigningKey ,
=- .
true/ 3
,3 4
IssuerSigningKey $
=% &
new' * 
SymmetricSecurityKey+ ?
(? @
key@ C
)C D
,D E
ValidateIssuer "
=# $
true% )
,) *
ValidateAudience   $
=  % &
true  ' +
,  + ,
	ClockSkew"" 
="" 
TimeSpan""  (
.""( )
Zero"") -
,""- .
ValidIssuer## 
=##  !
JwtDescription##" 0
.##0 1
Issuer##1 7
,##7 8
ValidAudience$$ !
=$$" #
JwtDescription$$$ 2
.$$2 3
Audience$$3 ;
}%% 
,%% 
out%% 
SecurityToken%% $
validatedToken%%% 3
)%%3 4
;%%4 5
var'' 
jwtToken'' 
='' 
(''  
JwtSecurityToken''  0
)''0 1
validatedToken''1 ?
;''? @
var)) 
listOfRoles)) 
=))  !
jwtToken))" *
.))* +
Claims))+ 1
.** 
Where** 
(** 
x** 
=>** 
x**  !
.**! "
Type**" &
==**' )
$str*** h
)**h i
.++ 
Select++ 
(++ 
x++ 
=>++  
x++! "
.++" #
Value++# (
)++( )
.,, 
FirstOrDefault,, #
(,,# $
),,$ %
;,,% &
if.. 
(.. 
listOfRoles.. 
==..  "
null..# '
)..' (
{// 
context00 
.00 
Result00 "
=00# $
new00% (
UnauthorizedResult00) ;
(00; <
)00< =
;00= >
return11 
;11 
}22 
var44 
	rolesName44 
=44 
listOfRoles44  +
.44+ ,
Split44, 1
(441 2
$char442 5
)445 6
.446 7
ToList447 =
(44= >
)44> ?
;44? @
var66 
passedRoles66 
=66  !
this66" &
.66& '
roles66' ,
.66, -
Split66- 2
(662 3
$char663 6
)666 7
.667 8
ToList668 >
(66> ?
)66? @
;66@ A
var88 
	roleExist88 
=88 
(88  !
from88! %
a88& '
in88( *
	rolesName88+ 4
join99! %
b99& '
in99( *
passedRoles99+ 6
on::! #
a::$ %
equals::& ,
b::- .
select;;! '
new;;( +
{;;, -
b;;. /
};;0 1
);;1 2
.;;2 3
ToList;;3 9
(;;9 :
);;: ;
;;;; <
if== 
(== 
	roleExist== 
.== 
Count== #
====$ &
$num==' (
)==( )
{>> 
context?? 
.?? 
Result?? "
=??# $
new??% (
UnauthorizedResult??) ;
(??; <
)??< =
;??= >
return@@ 
;@@ 
}AA 
}BB 
catchCC 
(CC 
	ExceptionCC 
exCC 
)CC  
{DD 
ConsoleEE 
.EE 
	WriteLineEE !
(EE! "
exEE" $
)EE$ %
;EE% &
contextFF 
.FF 
ResultFF 
=FF  
newFF! $
UnauthorizedResultFF% 7
(FF7 8
)FF8 9
;FF9 :
returnGG 
;GG 
}HH 
awaitII 
nextII 
(II 
)II 
;II 
}JJ 	
}KK 
}LL —
]C:\Users\BS01389\source\repos\SimpleBookStore\SimpleBookStore\Controllers\ReviewController.cs
	namespace 	
SimpleBookStore
 
. 
Controllers %
{ 
[		 
ApiController		 
]		 
[

 
Route

 

(


 
$str

 &
)

& '
]

' (
[ 
AuthorizationFilter 
( 
$str !
)! "
]" #
public 

class 
ReviewController !
:" #
ControllerBase$ 2
{ 
private 
readonly 
IMediaTr !
<! "
GiveReviewCommand" 3
,3 4
Task5 9
<9 :
(: ;
bool; ?
success@ G
,G H
stringI O
messageP W
,W X
stringY _
errorMessage` l
)l m
>m n
>n o
_giveReviewp {
;{ |
public 
ReviewController 
(  
IMediaTr  (
<( )
GiveReviewCommand) :
,: ;
Task< @
<@ A
(A B
boolB F
successG N
,N O
stringP V
messageW ^
,^ _
string` f
errorMessageg s
)s t
>t u
>u v

giveReview	w Å
)
Å Ç
{ 	
_giveReview 
= 

giveReview $
;$ %
} 	
[ 	
HttpPost	 
] 
public 
async 
Task 
< 
IActionResult '
>' (
SubmitReview) 5
(5 6
ReviewRequestModel6 H
modelI N
)N O
{ 	
if 
( 
! 

ModelState 
. 
IsValid #
)# $
return 

BadRequest !
(! "
new" %
{& '
success( /
=0 1
false2 7
,7 8
message9 @
=A B
stringC I
.I J
JoinJ N
(N O
$strO S
,S T

ModelStateU _
._ `
Values` f
.f g

SelectManyg q
(q r
vr s
=>t v
vw x
.x y
Errorsy 
)	 Ä
)
Ä Å
}
Ç É
)
É Ñ
;
Ñ Ö
var 
result 
= 
await 
_giveReview *
.* +
Send+ /
(/ 0
model0 5
)5 6
;6 7
if 
( 
! 
result 
. 
success 
)  
return 

BadRequest !
(! "
new" %
{& '
result( .
.. /
success/ 6
,6 7
result8 >
.> ?
message? F
}G H
)H I
;I J
return 
Ok 
( 
new 
{ 
result "
." #
success# *
,* +
result, 2
.2 3
message3 :
}; <
)< =
;= >
} 	
} 
}   ’
eC:\Users\BS01389\source\repos\SimpleBookStore\SimpleBookStore\Controllers\ReportDownloadController.cs
	namespace 	
SimpleBookStore
 
. 
Controllers %
{ 
[		 
ApiController		 
]		 
[

 
Route

 

(


 
$str

 &
)

& '
]

' (
public 

class $
ReportDownloadController )
:* +
ControllerBase, :
{ 
private 
readonly 
IMediaTr !
<! ",
 DownloadCommentByUserReportQuery" B
,B C
TaskD H
<H I
ResponseModelI V
<V W
stringW ]
>] ^
>^ _
>_ `(
_downloadCommentByUserReporta }
;} ~
public $
ReportDownloadController '
(' (
IMediaTr( 0
<0 1,
 DownloadCommentByUserReportQuery1 Q
,Q R
TaskS W
<W X
ResponseModelX e
<e f
stringf l
>l m
>m n
>n o(
downloadCommentByUserReport	p ã
)
ã å
{ 	(
_downloadCommentByUserReport (
=) *'
downloadCommentByUserReport+ F
;F G
} 	
[ 	
AuthorizationFilter	 
( 
$str )
)) *
]* +
[ 	
HttpGet	 
] 
public 
async 
Task 
< 
IActionResult '
>' (
CommentByUserReport) <
(< =
)= >
{ 	
var 
result 
= 
await (
_downloadCommentByUserReport ;
.; <
Send< @
(@ A
)A B
;B C
if 
( 
! 
result 
. 
Success 
)  
return 

BadRequest !
(! "
result" (
)( )
;) *
return 
Ok 
( 
result 
) 
; 
} 	
} 
} Ø.
cC:\Users\BS01389\source\repos\SimpleBookStore\SimpleBookStore\Controllers\RegistrationController.cs
	namespace 	
SimpleBookStore
 
. 
Controllers %
{		 
[

 
ApiController

 
]

 
[ 
Route 

(
 
$str &
)& '
]' (
public 

class "
RegistrationController '
:( )
ControllerBase* 8
{ 
private 
readonly 
IMediaTr !
<! "
OnBoardUserCommand" 4
,4 5
Task6 :
<: ;%
RegistrationResponseModel; T
>T U
>U V
_onboardUserW c
;c d
public "
RegistrationController %
(% &
IMediaTr& .
<. /
OnBoardUserCommand/ A
,A B
TaskC G
<G H%
RegistrationResponseModelH a
>a b
>b c
onboardUserd o
)o p
{ 	
_onboardUser 
= 
onboardUser &
;& '
} 	
[ 	
HttpPost	 
] 
public 
async 
Task 
< 
IActionResult '
>' (
UserRegistration) 9
(9 :$
RegistrationRequestModel: R
modelS X
)X Y
{ 	
if 
( 

ModelState 
. 
IsValid "
)" #
{ 
var 
result 
= 
await "
_onboardUser# /
./ 0
Send0 4
(4 5
new5 8
object9 ?
[? @
]@ A
{B C
modelD I
,I J
UtilityK R
.R S
ConstantS [
.[ \
Role\ `
.` a
Persona g
}h i
)i j
;j k
if 
( 
! 
result 
. 
Success #
)# $
return 

BadRequest %
(% &
new& )
{* +
success, 3
=4 5
result6 <
.< =
Success= D
,D E
messageF M
=N O
resultP V
.V W
MessageW ^
}_ `
)` a
;a b
} 
else 
{ 
List 
< 

ModelError 
>  
	allErrors! *
=+ ,

ModelState- 7
.7 8
Values8 >
.> ?

SelectMany? I
(I J
vJ K
=>L N
vO P
.P Q
ErrorsQ W
)W X
.X Y
ToListY _
(_ `
)` a
;a b
return   

BadRequest   !
(  ! "
new  " %
{  & '
success  ( /
=  0 1
false  2 7
,  7 8
message  9 @
=  A B
$str  C U
,  U V
errors  W ]
=  ^ _
	allErrors  ` i
}  j k
)  k l
;  l m
}!! 
return"" 
Ok"" 
("" 
new"" 
{"" 
success"" #
=""$ %
true""& *
,""* +
message"", 3
=""4 5
$str""6 J
}""K L
)""L M
;""M N
}$$ 	
[&& 	
HttpPost&&	 
]&& 
public'' 
async'' 
Task'' 
<'' 
IActionResult'' '
>''' ("
SuperAdminRegistration'') ?
(''? @$
RegistrationRequestModel''@ X
model''Y ^
)''^ _
{(( 	
if)) 
()) 

ModelState)) 
.)) 
IsValid)) "
)))" #
{** 
var++ 
result++ 
=++ 
await++ "
_onboardUser++# /
.++/ 0
Send++0 4
(++4 5
new++5 8
object++9 ?
[++? @
]++@ A
{++B C
model++D I
,++I J
Utility++K R
.++R S
Constant++S [
.++[ \
Role++\ `
.++` a

SuperAdmin++a k
}++l m
)++m n
;++n o
if,, 
(,, 
!,, 
result,, 
.,, 
Success,, #
),,# $
return-- 

BadRequest-- %
(--% &
new--& )
{--* +
success--, 3
=--4 5
result--6 <
.--< =
Success--= D
,--D E
message--F M
=--N O
result--P V
.--V W
Message--W ^
}--_ `
)--` a
;--a b
}.. 
else// 
{00 
List11 
<11 

ModelError11 
>11  
	allErrors11! *
=11+ ,

ModelState11- 7
.117 8
Values118 >
.11> ?

SelectMany11? I
(11I J
v11J K
=>11L N
v11O P
.11P Q
Errors11Q W
)11W X
.11X Y
ToList11Y _
(11_ `
)11` a
;11a b
return22 

BadRequest22 !
(22! "
new22" %
{22& '
success22( /
=220 1
false222 7
,227 8
message229 @
=22A B
$str22C U
,22U V
errors22W ]
=22^ _
	allErrors22` i
}22j k
)22k l
;22l m
}33 
return44 
Ok44 
(44 
new44 
{44 
success44 #
=44$ %
true44& *
,44* +
message44, 3
=444 5
$str446 J
}44K L
)44L M
;44M N
}55 	
}66 
}77 ë
cC:\Users\BS01389\source\repos\SimpleBookStore\SimpleBookStore\Controllers\PurchaseBookController.cs
	namespace 	
SimpleBookStore
 
. 
Controllers %
{		 
[

 
AuthorizationFilter

 
(

 
$str

 !
)

! "
]

" #
[ 
ApiController 
] 
[ 
Route 

(
 
$str &
)& '
]' (
public 

class "
PurchaseBookController '
:( )
ControllerBase* 8
{ 
private 
readonly 
IMediaTr !
<! "
BuyBookCommand" 0
,0 1
Task2 6
<6 7
ResponseModel7 D
>D E
>E F
_buyBookG O
;O P
public "
PurchaseBookController %
(% &
IMediaTr& .
<. /
BuyBookCommand/ =
,= >
Task? C
<C D
ResponseModelD Q
>Q R
>R S
buyBookT [
)[ \
{ 	
_buyBook 
= 
buyBook 
; 
} 	
[ 	
HttpPost	 
] 
public 
async 
Task 
< 
IActionResult '
>' (
BuyBook) 0
(0 1
BuyBookRequestModel1 D
modelE J
)J K
{ 	
if 
( 
! 

ModelState 
. 
IsValid #
)# $
return 

BadRequest  
(  !
new! $
{% &
Errors' -
=. /

ModelState0 :
.: ;
Values; A
.A B

SelectManyB L
(L M
vM N
=>O Q
vR S
.S T
ErrorsT Z
)Z [
}\ ]
)] ^
;^ _
var 
result 
= 
await 
_buyBook '
.' (
Send( ,
(, -
model- 2
)2 3
;3 4
if 
( 
! 
result 
. 
Success 
)  
return 

BadRequest !
(! "
result" (
)( )
;) *
return 
Ok 
( 
result 
) 
; 
} 	
}   
}!! ±
fC:\Users\BS01389\source\repos\SimpleBookStore\SimpleBookStore\Controllers\BookInformationController.cs
	namespace		 	
SimpleBookStore		
 
.		 
Controllers		 %
{

 
[ 
ApiController 
] 
[ 
Route 

(
 
$str &
)& '
]' (
[ 
AuthorizationFilter 
( 
$str !
)! "
]" #
public 

class %
BookInformationController *
:+ ,
ControllerBase- ;
{ 
private 
readonly 
IBookQueryService *
_bookQueryService+ <
;< =
public %
BookInformationController (
(( )
IBookQueryService) :
bookQueryService; K
)K L
{ 	
_bookQueryService 
= 
bookQueryService  0
;0 1
} 	
[ 	
HttpGet	 
] 
[ 	
Route	 
( 
$str '
)' (
]( )
public 
async 
Task 
< 
IActionResult '
>' (
BookList) 1
(1 2
int2 5
pageSize6 >
,> ?
int@ C
	pageIndexD M
)M N
{ 	
var 
result 
= 
await 
_bookQueryService 0
.0 1
BookListAsync1 >
(> ?
pageSize? G
,G H
	pageIndexI R
)R S
;S T
return 
Ok 
( 
result 
) 
; 
} 	
[ 	
HttpGet	 
] 
[ 	
Route	 
( 
$str '
)' (
]( )
public   
async   
Task   
<   
IActionResult   '
>  ' (
BookDetails  ) 4
(  4 5
int  5 8
pageSize  9 A
,  A B
int  C F
	pageIndex  G P
)  P Q
{!! 	
var"" 
result"" 
="" 
await"" 
_bookQueryService"" 0
.""0 1
BookDetailsAsync""1 A
(""A B
pageSize""B J
,""J K
	pageIndex""K T
)""T U
;""U V
return## 
Ok## 
(## 
result## 
)## 
;## 
}$$ 	
}%% 
}&& è
dC:\Users\BS01389\source\repos\SimpleBookStore\SimpleBookStore\Controllers\BookOperationController.cs
	namespace 	
SimpleBookStore
 
. 
Controllers %
{ 
[		 
ApiController		 
]		 
[

 
AuthorizationFilter

 
(

 
$str

 %
)

% &
]

& '
[ 
Route 

(
 
$str &
)& '
]' (
public 

class #
BookOperationController (
:) *
ControllerBase+ 9
{ 
private 
readonly 
IMediaTr !
<! "
AddBooksFromExcel" 3
,3 4
Task5 9
<9 :
ResponseModel: G
>G H
>H I
_addBookExcelJ W
;W X
public #
BookOperationController &
(& '
IMediaTr' /
</ 0
AddBooksFromExcel0 A
,A B
TaskC G
<G H
ResponseModelH U
>U V
>V W
addBookExcelX d
)d e
{ 	
_addBookExcel 
= 
addBookExcel (
;( )
} 	
[ 	
HttpPost	 
] 
public 
async 
Task 
< 
IActionResult '
>' (
BookBulkUpload) 7
(7 8
	IFormFile8 A
fileB F
)F G
{ 	
if 
( 
! 

ModelState 
. 
IsValid #
)# $
return 

BadRequest !
(! "
new" %
{& '
Errors( .
=/ 0

ModelState1 ;
.; <
Values< B
.B C

SelectManyC M
(M N
vN O
=>P R
vS T
.T U
ErrorsU [
)[ \
}] ^
)^ _
;_ `
var 
result 
= 
await 
_addBookExcel ,
., -
Send- 1
(1 2
new2 5
object6 <
[< =
]= >
{? @
fileA E
}F G
)G H
;H I
if 
( 
! 
result 
. 
Success 
)  
return 

BadRequest !
(! "
result" (
)( )
;) *
return 
Ok 
( 
result 
) 
; 
} 	
} 
}   ÷
[C:\Users\BS01389\source\repos\SimpleBookStore\SimpleBookStore\Controllers\AuthController.cs
	namespace 	
SimpleBookStore
 
. 
Controllers %
{ 
[		 
ApiController		 
]		 
[

 
Route

 

(


 
$str

 &
)

& '
]

' (
public 

class 
AuthController 
:  !
ControllerBase" 0
{ 
private 
readonly 
IMediaTr !
<! "
ValidateUserCommand" 5
,5 6
Task6 :
<: ;
ResponseModel; H
<H I
LoginResponseModelI [
>[ \
>\ ]
>] ^
_validateUser_ l
;l m
public 
AuthController 
( 
IMediaTr &
<& '
ValidateUserCommand' :
,: ;
Task< @
<@ A
ResponseModelA N
<N O
LoginResponseModelO a
>a b
>b c
>c d
validateUsere q
)q r
{ 	
_validateUser 
= 
validateUser (
;( )
} 	
[ 	
HttpPost	 
] 
public 
async 
Task 
< 
IActionResult '
>' (
TokenRequest) 5
(5 6
LoginRequestModel6 G
modelH M
)M N
{ 	
if 
( 
! 

ModelState 
. 
IsValid #
)# $
{ 
return 
Unauthorized #
(# $
new$ '
{( )
success* 1
=2 3
false4 9
,9 :
message; B
=C D
$strE ^
}_ `
)` a
;a b
} 
var 
result 
= 
await 
_validateUser ,
., -
Send- 1
(1 2
model2 7
)7 8
;8 9
if 
( 
! 
result 
. 
Success 
)  
return 
Unauthorized #
(# $
result$ *
)* +
;+ ,
return   
Ok   
(   
result   
)   
;   
}!! 	
}## 
}$$ ù
bC:\Users\BS01389\source\repos\SimpleBookStore\SimpleBookStore\Controllers\AdminReportController.cs
	namespace 	
SimpleBookStore
 
. 
Controllers %
{ 
[ 
ApiController 
] 
[ 
Route 

(
 
$str &
)& '
]' (
[		 
AuthorizationFilter		 
(		 
$str		 %
)		% &
]		& '
public

 

class

 !
AdminReportController

 &
:

' (
ControllerBase

) 7
{ 
private 
readonly 
IReportQueryService ,
_reportQueryService- @
;@ A
public !
AdminReportController $
($ %
IReportQueryService% 8
reportQueryService9 K
)K L
{ 	
_reportQueryService 
=  !
reportQueryService" 4
;4 5
} 	
[ 	
HttpGet	 
] 
public 
async 
Task 
< 
IActionResult '
>' (
CommentCountByUsers) <
(< =
)= >
{ 	
var 
result 
= 
await 
_reportQueryService 2
.2 3$
CommentCountByUsersAsync3 K
(K L
)L M
;M N
if 
( 
! 
result 
. 
Success 
)  
return 

BadRequest !
(! "
result" (
)( )
;) *
return 
Ok 
( 
result 
) 
; 
} 	
[ 	
HttpGet	 
] 
public 
async 
Task 
< 
IActionResult '
>' (
UserBookStats) 6
(6 7
)7 8
{ 	
var 
result 
= 
await 
_reportQueryService 2
.2 3
UserBookStatsAsync3 E
(E F
)F G
;G H
if 
( 
! 
result 
. 
Success 
)  
return   

BadRequest   !
(  ! "
result  " (
)  ( )
;  ) *
return!! 
Ok!! 
(!! 
result!! 
)!! 
;!! 
}"" 	
}## 
}$$ 