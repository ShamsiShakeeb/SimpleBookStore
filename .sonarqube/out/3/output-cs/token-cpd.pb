—
kC:\Users\BS01389\source\repos\SimpleBookStore\SimpleBookStore.CQ\Query\ReportQuery\GetUserBookStatsQuery.cs
	namespace 	
SimpleBookStore
 
. 
CQ 
. 
Query "
." #
ReportQuery# .
{ 
public 

class !
GetUserBookStatsQuery &
:' (
IEventHandler) 6
{ 
private		 
readonly		 
IStoreAdoContext		 )
_storeAdoContext		* :
;		: ;
public

 !
GetUserBookStatsQuery

 $
(

$ %
IStoreAdoContext

% 5
storeAdoContext

6 E
)

E F
{ 	
_storeAdoContext 
= 
storeAdoContext .
;. /
} 	
public 
async 
Task 
< 
( 
bool 
success  '
,' (
List) -
<- .
UserBookStatsReport. A
>A B
reportC I
,I J
stringK Q
messageR Y
,Y Z
string[ a
errorMessageb n
)n o
>o p
Handlerq x
(x y
)y z
{ 	
var 
query 
= 
$str -
;- .
var!! 
result!! 
=!! 
await!! 
_storeAdoContext!! /
.!!/ 0
SqlReadAsync!!0 <
<!!< =
List!!= A
<!!A B
UserBookStatsReport!!B U
>!!U V
>!!V W
(!!W X
query!!X ]
,!!] ^
new## 

Dictionary## 
<## 
string## %
,##% &
object##' -
>##- .
{$$ 
{%% 
$str%% !
,%%! "
Utility%%# *
.%%* +
Constant%%+ 3
.%%3 4
Role%%4 8
.%%8 9

SuperAdmin%%9 C
}%%D E
}&& 
)&& 
;&& 
return(( 
((( 
result(( 
.(( 
Success(( "
,((" #
result(($ *
.((* +
Data((+ /
,((/ 0
result((1 7
.((7 8
Message((8 ?
,((? @
result((A G
.((G H
	Exception((H Q
)((Q R
;((R S
})) 	
}** 
}++ Í
pC:\Users\BS01389\source\repos\SimpleBookStore\SimpleBookStore.CQ\Query\ReportQuery\GetCommentCountByUserQuery.cs
	namespace 	
SimpleBookStore
 
. 
CQ 
. 
Query "
." #
ReportQuery# .
{ 
public 

class &
GetCommentCountByUserQuery +
:, -
IEventHandler. ;
{ 
private		 
readonly		 
IStoreAdoContext		 )
_storeAdoContext		* :
;		: ;
public

 &
GetCommentCountByUserQuery

 )
(

) *
IStoreAdoContext

* :
storeAdoContext

; J
)

J K
{ 	
_storeAdoContext 
= 
storeAdoContext .
;. /
} 	
public 
async 
Task 
< 
( 
bool 
success  '
,' (
List) -
<- .$
CommentCountByUserReport. F
>F G
reportH N
,N O
stringP V
messageW ^
,^ _
string` f
errorMessageg s
)s t
>t u
Handlerv }
(} ~
)~ 
{ 	
var 
query 
= 
$str# :
;##: ;
var%% 
result%% 
=%% 
await%% 
_storeAdoContext%% /
.%%/ 0
SqlReadAsync%%0 <
<%%< =
List%%= A
<%%A B$
CommentCountByUserReport%%B Z
>%%Z [
>%%[ \
(%%\ ]
query%%] b
,%%b c
new'' 

Dictionary'' 
<'' 
string'' %
,''% &
object''' -
>''- .
{(( 
{)) 
$str)) !
,))! "
Utility))# *
.))* +
Constant))+ 3
.))3 4
Role))4 8
.))8 9

SuperAdmin))9 C
}))D E
}** 
)** 
;** 
return,, 
(,, 
result,, 
.,, 
Success,, "
,,," #
result,,$ *
.,,* +
Data,,+ /
,,,/ 0
result,,1 7
.,,7 8
Message,,8 ?
,,,? @
result,,A G
.,,G H
	Exception,,H Q
),,Q R
;,,R S
}-- 	
}.. 
}// ©
vC:\Users\BS01389\source\repos\SimpleBookStore\SimpleBookStore.CQ\Query\ReportQuery\DownloadCommentByUserReportQuery.cs
	namespace 	
SimpleBookStore
 
. 
CQ 
. 
Query "
." #
ReportQuery# .
{ 
public 

class ,
 DownloadCommentByUserReportQuery 1
:2 3
IEventHandler4 A
{ 
private		 
readonly		 
IMediaTr		 !
<		! "&
GetCommentCountByUserQuery		" <
,		< =
Task		> B
<		B C
(		C D
bool		D H
success		I P
,		P Q
List

 
<

 $
CommentCountByUserReport

 )
>

) *
report

+ 1
,

1 2
string

3 9
message

: A
,

A B
string

C I
errorMessage

J V
)

V W
>

W X
>

X Y"
_getCommentByUserQuery

Z p
;

p q
private 
readonly 

ILoadExcel #

_loadExcel$ .
;. /
public ,
 DownloadCommentByUserReportQuery /
(/ 0
IMediaTr0 8
<8 9&
GetCommentCountByUserQuery9 S
,S T
TaskU Y
<Y Z
(Z [
bool[ _
success` g
,g h
List 
< $
CommentCountByUserReport )
>) *
report+ 1
,1 2
string3 9
message: A
,A B
stringC I
errorMessageJ V
)V W
>W X
>X Y!
getCommentByUserQueryZ o
,o p

ILoadExcel 
	loadExcel  
)  !
{ 	"
_getCommentByUserQuery "
=# $!
getCommentByUserQuery% :
;: ;

_loadExcel 
= 
	loadExcel "
;" #
} 	
public 
async 
Task 
< 
( 
bool 
success  '
,' (
string) /
base640 6
,6 7
string8 >
message? F
,F G
stringH N
errorMessageO [
)[ \
>\ ]
Handler^ e
(e f
)f g
{ 	
var 
result 
= 
await "
_getCommentByUserQuery 5
.5 6
Send6 :
(: ;
); <
;< =
if 
( 
! 
result 
. 
success 
)  
return 
( 
result 
. 
success $
,$ %
null& *
,* +
result, 2
.2 3
message3 :
,: ;
result< B
.B C
errorMessageC O
)O P
;P Q
var 
excelResult 
= 

_loadExcel (
.( )
ListToExcelBase64) :
(: ;
$str; C
,C D
new 
List 
< 
string 
>  
(  !
)! "
{# $
$str% *
,* +
$str, 6
,6 7
$str8 ?
,? @
$strA I
,I J
$strK Y
}Z [
,[ \
result 
. 
report 
) 
; 
return 
excelResult 
; 
}   	
}!! 
}"" ò
dC:\Users\BS01389\source\repos\SimpleBookStore\SimpleBookStore.CQ\Query\BookQuery\GetBookListQuery.cs
	namespace 	
SimpleBookStore
 
. 
CQ 
. 
Query "
." #
	BookQuery# ,
{		 
public

 

class

 
GetBookListQuery

 !
:

" #
IEventHandler

$ 1
{ 
private 
readonly 
IRepository $
<$ %
Book% )
>) *
_repositoryBook+ :
;: ;
public 
GetBookListQuery 
(  
IRepository  +
<+ ,
Book, 0
>0 1
repositoryBook2 @
)@ A
{ 	
_repositoryBook 
= 
repositoryBook ,
;, -
} 	
public 
async 
Task 
< #
PaginationResponseModel 1
<1 2
BookResponseModel2 C
>C D
>D E
HandlerF M
(M N
intN Q
pageSizeR Z
=[ \
$num] _
,_ `
int` c
	pageIndexd m
=n o
$nump q
)q r
{ 	
var 
data 
= 
_repositoryBook &
.& '
Get' *
(* +
x+ ,
=>- /
true0 4
)4 5
.5 6
Select6 <
(< =
x= >
=>> @
newA D
BookResponseModelE V
(V W
)W X
{ 
Id 
= 
x 
. 
Id 
, 
Title 
= 
x 
. 
Title 
,  
Author 
= 
x 
. 
Author !
,! "
ISBN 
= 
x 
. 
ISBN 
, 
Price 
= 
x 
. 
Price 
,  
Stock 
= 
x 
. 
Stock 
,  
PublishedDate 
= 
x  !
.! "
PublishedDate" /
,/ 0
} 
) 
; 
var 

pagination 
= 
await "
data# '
.' (
PaginationAsync( 7
(7 8
pageSize8 @
,@ A
	pageIndexB K
)K L
;L M
return   

pagination   
;   
}!! 	
}"" 
}## ◊#
jC:\Users\BS01389\source\repos\SimpleBookStore\SimpleBookStore.CQ\Query\BookQuery\GetBookDetailInfoQuery.cs
	namespace		 	
SimpleBookStore		
 
.		 
CQ		 
.		 
Query		 "
.		" #
	BookQuery		# ,
{

 
public 

class "
GetBookDetailInfoQuery '
:( )
IEventHandler* 7
{ 
private 
readonly 
IRepository $
<$ %
Book% )
>) *
_repositoryBook+ :
;: ;
private 
readonly 
IRepository $
<$ %
Review% +
>+ ,
_repositoryReview- >
;> ?
private 
readonly 
UserManager $
<$ %
User% )
>) *
_userManager+ 7
;7 8
public "
GetBookDetailInfoQuery %
(% &
IRepository& 1
<1 2
Book2 6
>6 7
repositoryBook8 F
,F G
IRepository 
< 
Review 
> 
repositoryReview  0
,0 1
UserManager 
< 
User 
> 
userManager )
)) *
{ 	
_repositoryBook 
= 
repositoryBook ,
;, -
_repositoryReview 
= 
repositoryReview  0
;0 1
_userManager 
= 
userManager &
;& '
} 	
public 
async 
Task 
< #
PaginationResponseModel 1
<1 2!
BookInfoResponseModel2 G
>G H
>H I
HandlerJ Q
(Q R
intR U
pageSizeV ^
=_ `
$numa c
,c d
inte h
	pageIndexi r
=s t
$numu v
)v w
{ 	
var 
data 
= 
( 
from 
b 
in !
_repositoryBook" 1
.1 2
Get2 5
(5 6
)6 7
join 
r 
in !
_repositoryReview" 3
.3 4
Get4 7
(7 8
)8 9
on 
b 
. 
Id 
equals  &
r' (
.( )
BID) ,
join 
u 
in !
_userManager" .
.. /
Users/ 4
on   
r   
.   
UID    
equals  ! '
u  ( )
.  ) *
Id  * ,
select!! 
new!! "!
BookInfoResponseModel!!# 8
{"" 
Title## !
=##" #
b##$ %
.##% &
Title##& +
,##+ ,
Author$$ "
=$$# $
b$$% &
.$$& '
Author$$' -
,$$- .
ISBN%%  
=%%! "
b%%# $
.%%$ %
ISBN%%% )
,%%) *
Price&& !
=&&" #
b&&$ %
.&&% &
Price&&& +
,&&+ ,
PublishDate'' '
=''( )
b''* +
.''+ ,
PublishedDate'', 9
.''9 :
ToString'': B
(''B C
$str''C O
)''O P
,''P Q
Stock(( !
=((" #
b(($ %
.((% &
Stock((& +
,((+ ,
BookId)) "
=))# $
b))% &
.))& '
Id))' )
,))) *
UserName** $
=**% &
u**' (
.**( )
UserName**) 1
,**1 2
Email++ !
=++" #
u++$ %
.++% &
Email++& +
,+++ ,
UserId,, "
=,,# $
u,,% &
.,,& '
Id,,' )
,,,) *
Rating-- "
=--# $
r--% &
.--& '
Rating--' -
,--- .
Comment.. #
=..$ %
r..& '
...' (
Comment..( /
,../ 0
ReviewId// $
=//% &
r//' (
.//( )
Id//) +
}00 
)00 
;00 
var22 

pagination22 
=22 
await22 "
data22# '
.22' (
PaginationAsync22( 7
(227 8
pageSize228 @
,22@ A
	pageIndex22B K
)22K L
;22L M
return44 

pagination44 
;44 
}55 	
}66 
}77 ﬂ
dC:\Users\BS01389\source\repos\SimpleBookStore\SimpleBookStore.CQ\Configuration\DependencyResolver.cs
	namespace 	
SimpleBookStore
 
. 
CQ 
. 
Configuration *
{ 
public 

static 
class 
DependencyResolver *
{ 
public		 
static		 
IServiceCollection		 (
CQ		) +
(		+ ,
this		, 0
IServiceCollection		1 C
services		D L
)		L M
{

 	
services 
. 

AddMediaTr 
(  
)  !
;! "
services 
. 
ExcelFeature !
(! "
)" #
;# $
return 
services 
; 
} 	
} 
} §2
kC:\Users\BS01389\source\repos\SimpleBookStore\SimpleBookStore.CQ\Command\UserCommand\ValidateUserCommand.cs
	namespace 	
SimpleBookStore
 
. 
CQ 
. 
Command $
.$ %
UserCommand% 0
{ 
public 

class 
ValidateUserCommand $
:% &
IEventHandler' 4
{ 
private 
readonly 
UserManager $
<$ %
User% )
>) *
_userManager+ 7
;7 8
private 
readonly 
SignInManager &
<& '
User' +
>+ ,
_signManager- 9
;9 :
public 
ValidateUserCommand "
(" #
UserManager# .
<. /
User/ 3
>3 4
userManager5 @
,@ A
SignInManager 
< 
User 
> 
signManager  +
)+ ,
{ 	
_userManager 
= 
userManager &
;& '
_signManager 
= 
signManager &
;& '
} 	
public 
async 
Task 
< 
( 
bool 
success  '
,' (
LoginResponseModel) ;
response< D
,D E
stringF L
messageM T
)T U
>U V
HandlerW ^
(^ _
LoginRequestModel_ p
modelq v
)v w
{ 	
var 
response 
= 
new 
LoginResponseModel 1
(1 2
)2 3
;3 4
var 
login 
= 
await 
_signManager *
.* +
PasswordSignInAsync+ >
(> ?
model? D
.D E
UserNameE M
,M N
modelO T
.T U
PasswordU ]
,] ^
true_ c
,c d
falsee j
)j k
;k l
if 
( 
! 
login 
. 
	Succeeded  
)  !
return 
( 
false 
, 
null #
,# $
$str% 3
)3 4
;4 5
var   
user   
=   
await   
_userManager   )
.  ) *
FindByNameAsync  * 9
(  9 :
model  : ?
.  ? @
UserName  @ H
)  H I
;  I J
response!! 
.!! 
UserId!! 
=!! 
user!! "
.!!" #
Id!!# %
;!!% &
response"" 
."" 
Token"" 
="" 
await"" "
GenerateTokenAsync""# 5
(""5 6
user""6 :
)"": ;
;""; <
return$$ 
($$ 
true$$ 
,$$ 
response$$ "
,$$" #
$str$$$ 5
)$$5 6
;$$6 7
}%% 	
private&& 
async&& 
Task&& 
<&& 
string&& !
>&&! "
GenerateTokenAsync&&# 5
(&&5 6
User&&6 :
user&&; ?
)&&? @
{'' 	
if(( 
((( 
user(( 
is(( 
null(( 
||(( 
user((  $
.(($ %
UserName((% -
is((. 0
null((1 5
)((5 6
{)) 
return** 
null** 
;** 
}++ 
var-- 
securityKey-- 
=-- 
new-- ! 
SymmetricSecurityKey--" 6
(--6 7
Encoding--7 ?
.--? @
UTF8--@ D
.--D E
GetBytes--E M
(--M N
Utility--N U
.--U V
Constant--V ^
.--^ _
JwtDescription--_ m
.--m n
Key--n q
)--q r
)--r s
;--s t
var.. 
credentials.. 
=.. 
new.. !
SigningCredentials.." 4
(..4 5
securityKey..5 @
,..@ A
SecurityAlgorithms..B T
...T U

HmacSha256..U _
).._ `
;..` a
var// 
roles// 
=// 
await// 
_userManager// *
.//* +
GetRolesAsync//+ 8
(//8 9
user//9 =
)//= >
;//> ?
var00 
rolesCommaSeparated00 #
=00$ %
string00& ,
.00, -
Join00- 1
(001 2
$char002 5
,005 6
roles007 <
)00< =
;00= >
var11 
claims11 
=11 
new11 
[11 
]11 
{22 
new33 
Claim33 
(33 

ClaimTypes33 $
.33$ %
NameIdentifier33% 3
,333 4
user334 8
.338 9
UserName339 A
)33A B
,33B C
new44 
Claim44 
(44 
$str44 "
,44" #
user44# '
.44' (
Id44( *
)44* +
,44+ ,
new55 
Claim55 
(55 

ClaimTypes55 $
.55$ %
Role55% )
,55) *
rolesCommaSeparated55* =
)55= >
,55> ?
}66 
;66 
var77 
token77 
=77 
new77 
JwtSecurityToken77 ,
(77, -
Utility77- 4
.774 5
Constant775 =
.77= >
JwtDescription77> L
.77L M
Issuer77M S
,77S T
Utility88 
.88 
Constant88  
.88  !
JwtDescription88! /
.88/ 0
Audience880 8
,888 9
claims99 
,99 
expires:: 
::: 
DateTime:: !
.::! "
Now::" %
.::% &
AddHours::& .
(::. /
$num::/ 0
)::0 1
,::1 2
signingCredentials;; "
:;;" #
credentials;;$ /
);;/ 0
;;;0 1
return== 
new== #
JwtSecurityTokenHandler== .
(==. /
)==/ 0
.==0 1

WriteToken==1 ;
(==; <
token==< A
)==A B
;==B C
}>> 	
}?? 
}@@ Â3
jC:\Users\BS01389\source\repos\SimpleBookStore\SimpleBookStore.CQ\Command\UserCommand\OnBoardUserCommand.cs
	namespace 	
SimpleBookStore
 
. 
CQ 
. 
Command $
.$ %
UserCommand% 0
{ 
public		 

class		 
OnBoardUserCommand		 #
:		$ %
IEventHandler		& 3
{

 
private 
readonly 
UserManager $
<$ %
User% )
>) *
_userManager+ 7
;7 8
private 
readonly 
RoleManager $
<$ %
IdentityRole% 1
>1 2
_roleManager3 ?
;? @
public 
OnBoardUserCommand !
(! "
UserManager" -
<- .
User. 2
>2 3
userManager4 ?
,? @
RoleManager 
< 
IdentityRole $
>$ %
roleManager& 1
)1 2
{ 	
_userManager 
= 
userManager &
;& '
_roleManager 
= 
roleManager &
;& '
} 	
public 
async 
Task 
< %
RegistrationResponseModel 3
>3 4
Handler5 <
(< =$
RegistrationRequestModel= U
modelV [
,[ \
string] c
roled h
)h i
{ 	
var 
response 
= 
new %
RegistrationResponseModel 8
(8 9
)9 :
;: ;
try 
{ 
var 
user 
= 
new 
User #
(# $
)$ %
{ 
UserName 
= 
model $
.$ %
UserName% -
,- .
Email 
= 
model !
.! "
Email" '
,' (
PhoneNumber 
=  !
model" '
.' (
PhoneNumber( 3
,3 4
Age 
= 
model 
.  
Age  #
,# $
Gender 
= 
model "
." #
Gender# )
,) *
Address   
=   
model   #
.  # $
Address  $ +
,  + ,
}!! 
;!! 
var"" 
isExist"" 
="" 
await"" #
_roleManager""$ 0
.""0 1
RoleExistsAsync""1 @
(""@ A
role""A E
)""E F
;""F G
if$$ 
($$ 
!$$ 
isExist$$ 
)$$ 
{%% 
var&& 
roleCreation&& $
=&&% &
await&&' ,
_roleManager&&- 9
.&&9 :
CreateAsync&&: E
(&&E F
new&&F I
IdentityRole&&J V
(&&V W
role&&W [
)&&[ \
)&&\ ]
;&&] ^
if(( 
((( 
!(( 
roleCreation(( %
.((% &
	Succeeded((& /
)((/ 0
{)) 
response**  
.**  !
Success**! (
=**) *
roleCreation**+ 7
.**7 8
	Succeeded**8 A
;**A B
response++  
.++  !
Message++! (
=++) *
string+++ 1
.++1 2
Join++2 6
(++6 7
$str++7 ;
,++; <
roleCreation++= I
.++I J
Errors++J P
.++P Q
Select++Q W
(++W X
x++X Y
=>++Z \
x++] ^
.++^ _
Description++_ j
)++j k
)++k l
;++l m
return,, 
response,, '
;,,' (
}-- 
}.. 
var00 
userCreation00  
=00! "
await00# (
_userManager00) 5
.005 6
CreateAsync006 A
(00A B
user00B F
,00F G
model00H M
.00M N
Password00N V
)00V W
;00W X
if22 
(22 
!22 
userCreation22 !
.22! "
	Succeeded22" +
)22+ ,
{33 
response44 
.44 
Success44 $
=44% &
userCreation44' 3
.443 4
	Succeeded444 =
;44= >
response55 
.55 
Message55 $
=55% &
string55' -
.55- .
Join55. 2
(552 3
$str553 7
,557 8
userCreation559 E
.55E F
Errors55F L
.55L M
Select55M S
(55S T
x55T U
=>55V X
x55Y Z
.55Z [
Description55[ f
)55f g
)55g h
;55h i
return66 
response66 #
;66# $
}77 
var99 
addRole99 
=99 
await99 #
_userManager99$ 0
.990 1
AddToRoleAsync991 ?
(99? @
user99@ D
,99D E
role99F J
)99J K
;99K L
if;; 
(;; 
!;; 
addRole;; 
.;; 
	Succeeded;; &
);;& '
{<< 
response== 
.== 
Success== $
===% &
addRole==' .
.==. /
	Succeeded==/ 8
;==8 9
response>> 
.>> 
Message>> $
=>>% &
string>>' -
.>>- .
Join>>. 2
(>>2 3
$str>>3 7
,>>7 8
addRole>>9 @
.>>@ A
Errors>>A G
.>>G H
Select>>H N
(>>N O
x>>O P
=>>>Q S
x>>T U
.>>U V
Description>>V a
)>>a b
)>>b c
;>>c d
return?? 
response?? #
;??# $
}@@ 
responseBB 
.BB 
SuccessBB  
=BB! "
trueBB# '
;BB' (
responseCC 
.CC 
MessageCC  
=CC! "
$strCC# 6
;CC6 7
}DD 
catchEE 
(EE 
	ExceptionEE 
exEE 
)EE  
{FF 
responseGG 
.GG 
SuccessGG  
=GG! "
falseGG# (
;GG( )
responseHH 
.HH 
MessageHH  
=HH! "
exHH# %
.HH% &
MessageHH& -
;HH- .
}II 
returnKK 
responseKK 
;KK 
}LL 	
}MM 
}NN Ä.
kC:\Users\BS01389\source\repos\SimpleBookStore\SimpleBookStore.CQ\Command\ReviewCommand\GiveReviewCommand.cs
	namespace		 	
SimpleBookStore		
 
.		 
CQ		 
.		 
Command		 $
.		$ %
ReviewCommand		% 2
{

 
public 

class 
GiveReviewCommand "
:# $
IEventHandler% 2
{ 
private 
readonly 
IRepository $
<$ %
Review% +
>+ ,
_reviewRepository- >
;> ?
private 
readonly 
UserManager $
<$ %
User% )
>) *
_userManager+ 7
;7 8
private 
readonly 
IMediaTr !
<! "
AddLogCommand" /
,/ 0
Task1 5
>5 6
_logCommand7 B
;B C
private 
readonly 
IUnitOfWork $
<$ %
IStoreEntity% 1
>1 2
_storeUnitOfWork3 C
;C D
public 
GiveReviewCommand  
(  !
IRepository! ,
<, -
Review- 3
>3 4
reviewRepository5 E
,E F
UserManager 
< 
User 
> 
userManager )
,) *
IMediaTr 
< 
AddLogCommand "
," #
Task$ (
>( )

logCommand* 4
,4 5
IUnitOfWork 
< 
IStoreEntity $
>$ %
storeUnitOfWork& 5
)5 6
{ 	
_reviewRepository 
= 
reviewRepository  0
;0 1
_userManager 
= 
userManager &
;& '
_logCommand 
= 

logCommand $
;$ %
_storeUnitOfWork 
= 
storeUnitOfWork .
;. /
} 	
public 
async 
Task 
< 
( 
bool 
success  '
,' (
string) /
message0 7
,7 8
string9 ?
errorMessage@ L
)L M
>M N
HandlerO V
(V W
ReviewRequestModelW i
modelj o
)o p
{ 	
var 
user 
= 
await 
_userManager )
.) *
FindByIdAsync* 7
(7 8
model8 =
.= >
UID> A
)A B
;B C
if 
( 
user 
== 
null 
) 
{   
await!! 
_logCommand!! !
.!!! "
Send!!" &
(!!& '
new"" 
LogRequestModel"" '
(""' (
)""( )
{## 
Success$$ 
=$$  !
false$$" '
,$$' (
Message%% 
=%%  !
$str%%" 2
,%%2 3
ErrorMessage&& $
=&&% &
string&&' -
.&&- .
Format&&. 4
(&&4 5
$str&&5 Z
+&&[ \
$str'' 0
,''0 1
model''2 7
.''7 8
UID''8 ;
)''; <
}(( 
)(( 
;(( 
return)) 
()) 
false)) 
,)) 
$str)) /
,))/ 0
$str))1 >
)))> ?
;))? @
}** 
var,, 
result,, 
=,, 
await,, 
_storeUnitOfWork,, /
.,,/ 0
Commit,,0 6
(,,6 7
async,,7 <
(,,= >
),,> ?
=>,,@ B
{-- 
var.. 
insertModel.. 
=..  !
new.." %
Review..& ,
(.., -
)..- .
{// 
UID00 
=00 
model00 
.00  
UID00  #
,00# $
BID11 
=11 
model11 
.11  
BID11  #
,11# $
Comment22 
=22 
model22 #
.22# $
Comment22$ +
,22+ ,
Rating33 
=33 
model33 "
.33" #
Rating33# )
,33) *
	Createdby44 
=44 
user44  $
.44$ %
UserName44% -
,44- .
CreatedDate55 
=55  !
model55" '
.55' (
CreatedDate55( 3
,553 4
}66 
;66 
await77 
_reviewRepository77 '
.77' (
InsertAsync77( 3
(773 4
insertModel774 ?
)77? @
;77@ A
}88 
)88 
;88 
if;; 
(;; 
!;; 
result;; 
.;; 
success;; 
);;  
{<< 
await== 
_logCommand== !
.==! "
Send==" &
(==& '
new>> 
LogRequestModel>> '
(>>' (
)>>( )
{?? 
Success@@ 
=@@  !
false@@" '
,@@' (
MessageAA 
=AA  !
resultAA" (
.AA( )
messageAA) 0
,AA0 1
ErrorMessageBB $
=BB% &
stringBB' -
.BB- .
FormatBB. 4
(BB4 5
$strBB5 
,CC 
modelCC 
.CC  
UIDCC  #
,CC# $
resultCC% +
.CC+ ,
errorMessageCC, 8
)CC8 9
}DD 
)DD 
;DD 
}EE 
returnGG 
(GG 
resultGG 
.GG 
successGG "
,GG" #
resultGG$ *
.GG* +
messageGG+ 2
,GG2 3
nullGG4 8
)GG8 9
;GG9 :
}HH 	
}II 
}JJ ú
dC:\Users\BS01389\source\repos\SimpleBookStore\SimpleBookStore.CQ\Command\LogCommand\AddLogCommand.cs
	namespace 	
SimpleBookStore
 
. 
CQ 
. 
Command $
.$ %

LogCommand% /
{ 
public		 

class		 
AddLogCommand		 
:		  
IEventHandler		! .
{

 
private 
readonly 
IRepository $
<$ %
Logs% )
>) *
_repositoryLog+ 9
;9 :
private 
readonly 
IUnitOfWork $
<$ %

ILogEntity% /
>/ 0
_logUnitOfWork1 ?
;? @
public 
AddLogCommand 
( 
IRepository (
<( )
Logs) -
>- .
repositoryLog/ <
,< =
IUnitOfWork 
< 

ILogEntity "
>" #
logUnitOfWork$ 1
)1 2
{ 	
_repositoryLog 
= 
repositoryLog *
;* +
_logUnitOfWork 
= 
logUnitOfWork *
;* +
} 	
public 
async 
Task 
Handler !
(! "
LogRequestModel" 1
model2 7
)7 8
{ 	
await 
_logUnitOfWork  
.  !
Commit! '
(' (
async( -
(. /
)/ 0
=>1 3
{ 
await 
_repositoryLog $
.$ %
InsertAsync% 0
(0 1
new 
Logs 
( 
) 
{ 
Success 
= 
model #
.# $
Success$ +
,+ ,
Message 
= 
model #
.# $
Message$ +
,+ ,
ErrorMessage  
=! "
model# (
.( )
ErrorMessage) 5
,5 6
	Createdby 
= 
$str  (
,( )
CreatedDate 
=  !
DateTime" *
.* +
UtcNow+ 1
.1 2
AddHours2 :
(: ;
$num; <
)< =
} 
) 
; 
}   
)   
;   
}!! 	
}"" 
}## ü-
fC:\Users\BS01389\source\repos\SimpleBookStore\SimpleBookStore.CQ\Command\BookCommand\BuyBookCommand.cs
	namespace 	
SimpleBookStore
 
. 
CQ 
. 
Command $
.$ %
BookCommand% 0
{		 
public

 

class

 
BuyBookCommand

 
:

  !
IEventHandler

" /
{ 
private 
readonly 
IRepository $
<$ %
Book% )
>) *
_repositoryBook+ :
;: ;
private 
readonly 
IRepository $
<$ %
UserBook% -
>- .
_repositoryUserBook/ B
;B C
private 
readonly 
IUnitOfWork $
<$ %
IStoreEntity% 1
>1 2
_storeUnitWork3 A
;A B
private 
readonly 
IMediaTr !
<! "
AddLogCommand" /
,/ 0
Task1 5
>5 6
_logCommand7 B
;B C
public 
BuyBookCommand 
( 
IRepository )
<) *
Book* .
>. /
repositoryBook0 >
,> ?
IRepository 
< 
UserBook  
>  !
repositoryUserBook" 4
,4 5
IUnitOfWork 
< 
IStoreEntity $
>$ %
storeUnitWork& 3
,3 4
IMediaTr 
< 
AddLogCommand "
," #
Task$ (
>( )

logCommand* 4
)4 5
{ 	
_repositoryBook 
= 
repositoryBook ,
;, -
_repositoryUserBook 
=  !
repositoryUserBook" 4
;4 5
_storeUnitWork 
= 
storeUnitWork *
;* +
_logCommand 
= 

logCommand $
;$ %
} 	
public 
async 
Task 
< 
( 
bool 
success  '
,' (
string) /
message0 7
,7 8
string9 ?
errorMessage@ L
)L M
>M N
HandlerO V
(V W
BuyBookRequestModelW j
modelk p
)p q
{ 	
var 
bookInfo 
= 
await  
_repositoryBook! 0
.0 1
	GetEntity1 :
(: ;
x; <
=>= ?
x@ A
.A B
IdB D
==E G
modelH M
.M N
BookIdN T
)T U
;U V
if 
( 
bookInfo 
is 
null  
)  !
{ 
await   
_logCommand   !
.  ! "
Send  " &
(  & '
new  ' *
LogRequestModel  + :
(  : ;
)  ; <
{!! 
Success"" 
="" 
false"" #
,""# $
Message## 
=## 
$str## .
,##. /
ErrorMessage$$  
=$$! "
string$$# )
.$$) *
Format$$* 0
($$0 1
$str$$1 `
+$$a b
$str%% .
,%%. /
model%%0 5
.%%5 6
BookId%%6 <
,%%< =
model%%> C
.%%C D
UserId%%D J
)%%J K
}&& 
)&& 
;&& 
return'' 
('' 
false'' 
,'' 
$str'' /
,''/ 0
$str''1 Y
)''Y Z
;''Z [
}(( 
else** 
if** 
(** 
bookInfo** 
.** 
Stock** #
==**$ &
$num**' (
)**( )
{++ 
await,, 
_logCommand,, !
.,,! "
Send,," &
(,,& '
new,,' *
LogRequestModel,,+ :
(,,: ;
),,; <
{-- 
Success.. 
=.. 
false.. #
,..# $
Message// 
=// 
$str// C
,//C D
ErrorMessage00  
=00! "
string00# )
.00) *
Format00* 0
(000 1
$str001 `
+00a b
$str11 ,
,11, -
model11. 3
.113 4
BookId114 :
,11: ;
model11< A
.11A B
UserId11B H
)11H I
}22 
)22 
;22 
return33 
(33 
false33 
,33 
$str33 D
,33D E
null33F J
)33J K
;33K L
}44 
return66 
await66 
_storeUnitWork66 '
.66' (
Commit66( .
(66. /
async66/ 4
(665 6
)666 7
=>668 :
{77 
var88 
insertModel88 
=88  !
new88" %
UserBook88& .
(88. /
)88/ 0
{99 
BookId:: 
=:: 
model:: "
.::" #
BookId::# )
,::) *
UserId;; 
=;; 
model;; "
.;;" #
UserId;;# )
}<< 
;<< 
await>> 
_repositoryUserBook>> )
.>>) *
InsertAsync>>* 5
(>>5 6
insertModel>>6 A
)>>A B
;>>B C
bookInfo@@ 
.@@ 
Stock@@ 
-=@@ !
$num@@" #
;@@# $
_repositoryBookAA 
.AA  
UpdateAA  &
(AA& '
bookInfoAA' /
)AA/ 0
;AA0 1
}BB 
)BB 
;BB 
}CC 	
}EE 
}FF ò;
iC:\Users\BS01389\source\repos\SimpleBookStore\SimpleBookStore.CQ\Command\BookCommand\AddBooksFromExcel.cs
	namespace 	
SimpleBookStore
 
. 
CQ 
. 
Command $
.$ %
BookCommand% 0
{ 
public 

class 
AddBooksFromExcel "
:# $
IEventHandler% 2
{ 
private 
readonly 
IRepository $
<$ %
Book% )
>) *
_repositoryBook+ :
;: ;
private 
readonly 
IUnitOfWork $
<$ %
IStoreEntity% 1
>1 2
_storeUnitWork3 A
;A B
private 
readonly 
IMediaTr !
<! "
AddLogCommand" /
,/ 0
Task1 5
>5 6
_logCommand7 B
;B C
private 
readonly 

ILoadExcel #

_loadExcel$ .
;. /
public 
AddBooksFromExcel  
(  !
IRepository! ,
<, -
Book- 1
>1 2
repositoryBook3 A
,A B
IUnitOfWork 
< 
IStoreEntity $
>$ %
storeUnitWork& 3
,3 4
IMediaTr 
< 
AddLogCommand "
," #
Task$ (
>( )

logCommand* 4
,4 5

ILoadExcel 
	loadExcel  
)  !
{ 	
_repositoryBook 
= 
repositoryBook ,
;, -
_storeUnitWork 
= 
storeUnitWork *
;* +
_logCommand 
= 

logCommand $
;$ %

_loadExcel 
= 
	loadExcel "
;" #
} 	
public 
async 
Task 
< 
( 
bool 
success  '
,' (
string( .
message/ 6
,6 7
string7 =
errorMessage> J
)J K
>K L
HandlerM T
(T U
	IFormFileU ^
file_ c
)c d
{ 	
if   
(   
file   
==   
null   
||   
file    $
.  $ %
Length  % +
==  , .
$num  / 0
)  0 1
{!! 
await"" 
_logCommand"" !
.""! "
Send""" &
(""& '
new## 
LogRequestModel## $
(##$ %
)##% &
{$$ 
Success%% 
=%% 
false%% $
,%%$ %
Message&& 
=&& 
$str&& P
,&&P Q
ErrorMessage'' !
=''" #
$str''$ x
,''x y
}(( 
)(( 
;(( 
return)) 
()) 
false)) 
,)) 
$str)) 5
,))5 6
$str))7 L
)))L M
;))M N
}** 
var,, 
result,, 
=,, 

_loadExcel,, #
.,,# $
Fetch,,$ )
(,,) *
file,,* .
,,,. /
$str,,0 8
),,8 9
;,,9 :
List-- 
<-- 
Book-- 
>-- 
books-- 
=-- 
new-- "
List--# '
<--' (
Book--( ,
>--, -
(--- .
)--. /
;--/ 0
foreach.. 
(.. 
var.. 
r.. 
in.. 
result.. $
...$ %
data..% )
)..) *
{// 
var00 
book00 
=00 
new00 
Book00 #
(00# $
)00$ %
{11 
Title22 
=22 
r22 
.22 
Where22 #
(22# $
x22$ %
=>22& (
x22) *
.22* +

ColumnName22+ 5
.225 6
Trim226 :
(22: ;
)22; <
==22= ?
$str22@ G
)22G H
.22H I
Select22I O
(22O P
x22P Q
=>22R T
x22U V
.22V W
ColumnValue22W b
)22b c
.22c d
FirstOrDefault22d r
(22r s
)22s t
,22t u
Author33 
=33 
r33 
.33 
Where33 $
(33$ %
x33% &
=>33' )
x33* +
.33+ ,

ColumnName33, 6
.336 7
Trim337 ;
(33; <
)33< =
==33> @
$str33A I
)33I J
.33J K
Select33K Q
(33Q R
x33R S
=>33T V
x33W X
.33X Y
ColumnValue33Y d
)33d e
.33e f
FirstOrDefault33f t
(33t u
)33u v
,33v w
ISBN44 
=44 
r44 
.44 
Where44 "
(44" #
x44# $
=>44% '
x44( )
.44) *

ColumnName44* 4
.444 5
Trim445 9
(449 :
)44: ;
==44< >
$str44? E
)44E F
.44F G
Select44G M
(44M N
x44N O
=>44P R
x44S T
.44T U
ColumnValue44U `
)44` a
.44a b
FirstOrDefault44b p
(44p q
)44q r
,44r s
Price55 
=55 
r55 
.55 
Where55 #
(55# $
x55$ %
=>55& (
x55) *
.55* +

ColumnName55+ 5
.555 6
Trim556 :
(55: ;
)55; <
==55= ?
$str55@ G
)55G H
.55H I
Select55I O
(55O P
x55P Q
=>55R T
Convert55U \
.55\ ]
	ToDecimal55] f
(55f g
x55g h
.55h i
ColumnValue55i t
)55t u
)55u v
.66 
FirstOrDefault66 #
(66# $
)66$ %
,66% &
PublishedDate77 !
=77" #
r77$ %
.77% &
Where77& +
(77+ ,
x77, -
=>77. 0
x771 2
.772 3

ColumnName773 =
.77= >
Trim77> B
(77B C
)77C D
==77E G
$str77H W
)77W X
.77X Y
Select77Y _
(77_ `
x77` a
=>77b d
DateTime77e m
.77m n
Parse77n s
(77s t
x77t u
.77u v
ColumnValue	77v Å
,
77Å Ç
CultureInfo
77É é
.
77é è
InvariantCulture
77è ü
)
77ü †
)
77† °
.88 
FirstOrDefault88 #
(88# $
)88$ %
,88% &
	Createdby99 
=99 
Utility99  '
.99' (
Constant99( 0
.990 1
Role991 5
.995 6

SuperAdmin996 @
,99@ A
};; 
;;; 
books<< 
.<< 
Add<< 
(<< 
book<< 
)<< 
;<<  
}== 
return?? 
await?? 
_storeUnitWork?? '
.??' (
Commit??( .
(??. /
async??/ 4
(??5 6
)??6 7
=>??8 :
{@@ 
awaitAA 
_repositoryBookAA %
.AA% &
InsertRangeAsyncAA& 6
(AA6 7
booksAA7 <
)AA< =
;AA= >
}BB 
)BB 
;BB 
}CC 	
}DD 
}EE 