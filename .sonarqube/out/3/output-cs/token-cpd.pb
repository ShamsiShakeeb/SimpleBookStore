Ÿ^
eC:\Users\BS01389\source\repos\SimpleBookStore\SimpleBookStore.BLL\Services\UserService\UserService.cs
	namespace

 	
SimpleBookStore


 
.

 
BLL

 
.

 
Services

 &
.

& '
UserService

' 2
{ 
public 

class 
UserService 
: 
IUserService +
{ 
private 
readonly 
UserManager $
<$ %
User% )
>) *
_userManager+ 7
;7 8
private 
readonly 
SignInManager &
<& '
User' +
>+ ,
_signManager- 9
;9 :
private 
readonly 
RoleManager $
<$ %
IdentityRole% 1
>1 2
_roleManager3 ?
;? @
public 
UserService 
( 
UserManager &
<& '
User' +
>+ ,
userManager- 8
,8 9
SignInManager 
< 
User 
> 
signManager  +
,+ ,
RoleManager 
< 
IdentityRole $
>$ %
roleManager& 1
)1 2
{ 	
_userManager 
= 
userManager &
;& '
_signManager 
= 
signManager &
;& '
_roleManager 
= 
roleManager &
;& '
} 	
public 
async 
Task 
< %
RegistrationResponseModel 3
>3 4
OnBoardUser5 @
(@ A$
RegistrationRequestModelA Y
modelZ _
,_ `
stringa g
roleh l
)l m
{ 	
var 
response 
= 
new %
RegistrationResponseModel 8
(8 9
)9 :
;: ;
try 
{ 
var 
user 
= 
new 
User #
(# $
)$ %
{   
UserName!! 
=!! 
model!! $
.!!$ %
UserName!!% -
,!!- .
Email"" 
="" 
model"" !
.""! "
Email""" '
,""' (
PhoneNumber## 
=##  !
model##" '
.##' (
PhoneNumber##( 3
,##3 4
Age$$ 
=$$ 
model$$ 
.$$  
Age$$  #
,$$# $
Gender%% 
=%% 
model%% "
.%%" #
Gender%%# )
,%%) *
Address&& 
=&& 
model&& #
.&&# $
Address&&$ +
,&&+ ,
}'' 
;'' 
var(( 
isExist(( 
=(( 
await(( #
_roleManager(($ 0
.((0 1
RoleExistsAsync((1 @
(((@ A
role((A E
)((E F
;((F G
if** 
(** 
!** 
isExist** 
)** 
{++ 
var,, 
roleCreation,, $
=,,% &
await,,' ,
_roleManager,,- 9
.,,9 :
CreateAsync,,: E
(,,E F
new,,F I
IdentityRole,,J V
(,,V W
role,,W [
),,[ \
),,\ ]
;,,] ^
if.. 
(.. 
!.. 
roleCreation.. %
...% &
	Succeeded..& /
)../ 0
{// 
response00  
.00  !
Success00! (
=00) *
roleCreation00+ 7
.007 8
	Succeeded008 A
;00A B
response11  
.11  !
Message11! (
=11) *
string11+ 1
.111 2
Join112 6
(116 7
$str117 ;
,11; <
roleCreation11= I
.11I J
Errors11J P
.11P Q
Select11Q W
(11W X
x11X Y
=>11Z \
x11] ^
.11^ _
Description11_ j
)11j k
)11k l
;11l m
return22 
response22 '
;22' (
}33 
}44 
var66 
userCreation66  
=66! "
await66# (
_userManager66) 5
.665 6
CreateAsync666 A
(66A B
user66B F
,66F G
model66H M
.66M N
Password66N V
)66V W
;66W X
if88 
(88 
!88 
userCreation88 !
.88! "
	Succeeded88" +
)88+ ,
{99 
response:: 
.:: 
Success:: $
=::% &
userCreation::' 3
.::3 4
	Succeeded::4 =
;::= >
response;; 
.;; 
Message;; $
=;;% &
string;;' -
.;;- .
Join;;. 2
(;;2 3
$str;;3 7
,;;7 8
userCreation;;9 E
.;;E F
Errors;;F L
.;;L M
Select;;M S
(;;S T
x;;T U
=>;;U W
x;;X Y
.;;Y Z
Description;;Z e
);;e f
);;f g
;;;g h
return<< 
response<< #
;<<# $
}== 
var?? 
addRole?? 
=?? 
await?? #
_userManager??$ 0
.??0 1
AddToRoleAsync??1 ?
(??? @
user??@ D
,??D E
role??F J
)??J K
;??K L
ifAA 
(AA 
!AA 
addRoleAA 
.AA 
	SucceededAA &
)AA& '
{BB 
responseCC 
.CC 
SuccessCC $
=CC% &
addRoleCC' .
.CC. /
	SucceededCC/ 8
;CC8 9
responseDD 
.DD 
MessageDD $
=DD% &
stringDD' -
.DD- .
JoinDD. 2
(DD2 3
$strDD3 7
,DD7 8
addRoleDD9 @
.DD@ A
ErrorsDDA G
.DDG H
SelectDDH N
(DDN O
xDDO P
=>DDP R
xDDS T
.DDT U
DescriptionDDU `
)DD` a
)DDa b
;DDb c
returnEE 
responseEE #
;EE# $
}FF 
responseHH 
.HH 
SuccessHH  
=HH! "
trueHH# '
;HH' (
responseII 
.II 
MessageII  
=II! "
$strII# 6
;II6 7
}JJ 
catchKK 
(KK 
	ExceptionKK 
exKK 
)KK  
{LL 
responseMM 
.MM 
SuccessMM  
=MM! "
falseMM# (
;MM( )
responseNN 
.NN 
MessageNN  
=NN! "
exNN# %
.NN% &
MessageNN& -
;NN- .
}OO 
returnQQ 
responseQQ 
;QQ 
}RR 	
publicSS 
asyncSS 
TaskSS 
<SS 
(SS 
boolSS 
successSS  '
,SS' (
LoginResponseModelSS) ;
responseSS< D
,SSD E
stringSSF L
messageSSM T
)SST U
>SSU V
ValidateUserSSW c
(SSc d
stringSSd j
userNameSSk s
,SSs t
stringSSu {
password	SS| Ñ
)
SSÑ Ö
{TT 	
varUU 
responseUU 
=UU 
newUU 
LoginResponseModelUU 1
(UU1 2
)UU2 3
;UU3 4
varWW 
loginWW 
=WW 
awaitWW 
_signManagerWW *
.WW* +
PasswordSignInAsyncWW+ >
(WW> ?
userNameWW? G
,WWG H
passwordWWH P
,WWP Q
trueWWR V
,WWV W
falseWWX ]
)WW] ^
;WW^ _
ifYY 
(YY 
!YY 
loginYY 
.YY 
	SucceededYY 
)YY  
returnZZ 
(ZZ 
falseZZ 
,ZZ 
nullZZ #
,ZZ# $
$strZZ% 3
)ZZ3 4
;ZZ4 5
var\\ 
user\\ 
=\\ 
await\\ 
_userManager\\ )
.\\) *
FindByNameAsync\\* 9
(\\9 :
userName\\: B
)\\B C
;\\C D
response]] 
.]] 
UserId]] 
=]] 
user]] "
.]]" #
Id]]# %
;]]% &
response^^ 
.^^ 
Token^^ 
=^^ 
await^^ "
GenerateTokenAsync^^# 5
(^^5 6
user^^6 :
)^^: ;
;^^; <
return`` 
(`` 
true`` 
,`` 
response`` !
,``! "
$str``" 3
)``3 4
;``4 5
}aa 	
privatecc 
asynccc 
Taskcc 
<cc 
stringcc !
>cc! "
GenerateTokenAsynccc# 5
(cc5 6
Usercc6 :
usercc; ?
)cc? @
{dd 	
ifee 
(ee 
useree 
isee 
nullee 
||ee 
useree  $
.ee$ %
UserNameee% -
isee. 0
nullee1 5
)ee5 6
{ff 
returngg 
nullgg 
;gg 
}hh 
varjj 
securityKeyjj 
=jj 
newjj ! 
SymmetricSecurityKeyjj" 6
(jj6 7
Encodingjj7 ?
.jj? @
UTF8jj@ D
.jjD E
GetBytesjjE M
(jjM N
UtilityjjN U
.jjU V
ConstantjjV ^
.jj^ _
JWTDescriptionjj_ m
.jjm n
Keyjjn q
)jjq r
)jjr s
;jjs t
varkk 
credentialskk 
=kk 
newkk !
SigningCredentialskk" 4
(kk4 5
securityKeykk5 @
,kk@ A
SecurityAlgorithmskkB T
.kkT U

HmacSha256kkU _
)kk_ `
;kk` a
varll 
rolesll 
=ll 
awaitll 
_userManagerll *
.ll* +
GetRolesAsyncll+ 8
(ll8 9
userll9 =
)ll= >
;ll> ?
varmm 
rolesCommaSeparatedmm #
=mm$ %
stringmm& ,
.mm, -
Joinmm- 1
(mm1 2
$charmm2 5
,mm5 6
rolesmm7 <
)mm< =
;mm= >
varnn 
claimsnn 
=nn 
newnn 
[nn 
]nn 
{oo 
newpp 
Claimpp 
(pp 

ClaimTypespp $
.pp$ %
NameIdentifierpp% 3
,pp3 4
userpp4 8
.pp8 9
UserNamepp9 A
)ppA B
,ppB C
newqq 
Claimqq 
(qq 
$strqq "
,qq" #
userqq# '
.qq' (
Idqq( *
)qq* +
,qq+ ,
newrr 
Claimrr 
(rr 

ClaimTypesrr $
.rr$ %
Rolerr% )
,rr) *
rolesCommaSeparatedrr* =
)rr= >
,rr> ?
}ss 
;ss 
vartt 
tokentt 
=tt 
newtt 
JwtSecurityTokentt ,
(tt, -
Utilitytt- 4
.tt4 5
Constanttt5 =
.tt= >
JWTDescriptiontt> L
.ttL M
IssuerttM S
,ttS T
Utilityuu 
.uu 
Constantuu  
.uu  !
JWTDescriptionuu! /
.uu/ 0
Audienceuu0 8
,uu8 9
claimsvv 
,vv 
expiresww 
:ww 
DateTimeww !
.ww! "
Nowww" %
.ww% &
AddHoursww& .
(ww. /
$numww/ 0
)ww0 1
,ww1 2
signingCredentialsxx "
:xx" #
credentialsxx$ /
)xx/ 0
;xx0 1
returnzz 
newzz #
JwtSecurityTokenHandlerzz .
(zz. /
)zz/ 0
.zz0 1

WriteTokenzz1 ;
(zz; <
tokenzz< A
)zzA B
;zzB C
}{{ 	
}|| 
}}} ´
fC:\Users\BS01389\source\repos\SimpleBookStore\SimpleBookStore.BLL\Services\UserService\IUserService.cs
	namespace 	
SimpleBookStore
 
. 
BLL 
. 
Services &
.& '
UserService' 2
{ 
public 

	interface 
IUserService !
{ 
Task 
< %
RegistrationResponseModel &
>& '
OnBoardUser( 3
(3 4$
RegistrationRequestModel4 L
modelM R
,R S
stringT Z
role[ _
)_ `
;` a
Task		 
<		 
(		 
bool		 
success		 
,		 
LoginResponseModel		 .
response		/ 7
,		7 8
string		9 ?
message		@ G
)		G H
>		H I
ValidateUser		J V
(		V W
string		W ]
userName		^ f
,		f g
string		h n
password		o w
)		w x
;		x y
}

 
} ∑/
iC:\Users\BS01389\source\repos\SimpleBookStore\SimpleBookStore.BLL\Services\ReviewService\ReviewService.cs
	namespace		 	
SimpleBookStore		
 
.		 
BLL		 
.		 
Services		 &
.		& '
ReviewService		' 4
{

 
public 

class 
ReviewService 
:  
IReviewService! /
{ 
private 
readonly 
IReviewRepository *
_reviewRepository+ <
;< =
private 
readonly 
UserManager $
<$ %
User% )
>) *
_userManager+ 7
;7 8
private 
readonly 
ILogService $
_logService% 0
;0 1
private 
readonly 
IStoreUnitOfWork )
_storeUnitOfWork* :
;: ;
public 
ReviewService 
( 
IReviewRepository .
reviewRepository/ ?
,? @
UserManager 
< 
User 
> 
userManager )
,) *
ILogService 

logService "
," #
IStoreUnitOfWork 
storeUnitOfWork ,
), -
{ 	
_reviewRepository 
= 
reviewRepository  0
;0 1
_userManager 
= 
userManager &
;& '
_logService 
= 

logService $
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
>M N

GiveReviewO Y
(Y Z
ReviewRequestModelZ l
modelm r
)r s
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
_logService!! !
.!!! "
	InsertLog!!" +
(!!+ ,
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
.,,/ 0
CommitAsync,,0 ;
<,,; <
(,,< =
bool,,= A
success,,B I
,,,I J
string,,K Q
message,,R Y
,,,Y Z
string,,[ a
errorMessage,,b n
),,n o
>,,o p
(,,p q
async,,q v
(,,w x
),,x y
=>,,z |
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
;66 
var88 
result88 
=88 
await88 "
_reviewRepository88# 4
.884 5
InsertAsync885 @
(88@ A
insertModel88A L
)88L M
;88M N
return99 
(99 
result99 
.99 
success99 &
,99& '
result99' -
.99- .
message99. 5
,995 6
result996 <
.99< =
errorMessage99= I
)99I J
;99J K
}:: 
):: 
;:: 
if== 
(== 
!== 
result== 
.== 
success== 
)==  
{>> 
await?? 
_logService?? !
.??! "
	InsertLog??" +
(??+ ,
new@@ 
LogRequestModel@@ '
(@@' (
)@@( )
{AA 
SuccessBB 
=BB  !
falseBB" '
,BB' (
MessageCC 
=CC  !
resultCC" (
.CC( )
messageCC) 0
,CC0 1
ErrorMessageDD $
=DD% &
stringDD' -
.DD- .
FormatDD. 4
(DD4 5
$strDD5 
,EE 
modelEE 
.EE 
UIDEE "
,EE" #
resultEE# )
.EE) *
errorMessageEE* 6
)EE6 7
}FF 
)FF 
;FF 
}GG 
returnII 
(II 
resultII 
.II 
successII "
,II" #
resultII$ *
.II* +
messageII+ 2
,II2 3
nullII4 8
)II8 9
;II9 :
}JJ 	
}KK 
}LL Ó
jC:\Users\BS01389\source\repos\SimpleBookStore\SimpleBookStore.BLL\Services\ReviewService\IReviewService.cs
	namespace 	
SimpleBookStore
 
. 
BLL 
. 
Services &
.& '
ReviewService' 4
{ 
public 

	interface 
IReviewService #
{ 
Task 
< 
( 
bool 
success 
, 
string "
message# *
,* +
string, 2
errorMessage3 ?
)? @
>@ A

GiveReviewB L
(L M
ReviewRequestModelM _
model` e
)e f
;f g
} 
}		 ˘=
iC:\Users\BS01389\source\repos\SimpleBookStore\SimpleBookStore.BLL\Services\ReportService\ReportService.cs
	namespace 	
SimpleBookStore
 
. 
BLL 
. 
Services &
.& '
ReportService' 4
{ 
public 

class 
ReportService 
:  
IReportService! /
{		 
private

 
readonly

 
IReportRepository

 *
_reportRepository

+ <
;

< =
public 
ReportService 
( 
IReportRepository .
reportRepository/ ?
)? @
{ 	
_reportRepository 
= 
reportRepository  0
;0 1
} 	
public 
async 
Task 
< 
( 
bool 
success  '
,' (
List) -
<- .$
CommentCountByUserReport. F
>F G
reportH N
,N O
stringP V
messageW ^
,^ _
string` f
errorMessageg s
)s t
>t u#
GetCommentCountByUsers	v å
(
å ç
)
ç é
{ 	
return 
await 
_reportRepository *
.* +"
GetCommentCountByUsers+ A
(A B
)B C
;C D
} 	
public 
async 
Task 
< 
( 
bool 
success  '
,' (
List) -
<- .
UserBookStatsReport. A
>A B
reportC I
,I J
stringK Q
messageR Y
,Y Z
string[ a
errorMessageb n
)n o
>o p
UserBookStatsq ~
(~ 
)	 Ä
{ 	
return 
await 
_reportRepository *
.* +
UserBookStats+ 8
(8 9
)9 :
;: ;
} 	
public 
async 
Task 
< 
( 
bool 
success  '
,' (
string( .
base64/ 5
,5 6
string6 <
message= D
,D E
stringE K
errorMessageL X
)X Y
>Y Z'
DownloadCommentByUserReport[ v
(v w
)w x
{ 	
var 
result 
= 
await 
_reportRepository 0
.0 1"
GetCommentCountByUsers1 G
(G H
)H I
;I J
if 
( 
! 
result 
. 
success 
)  
return 
( 
result 
. 
success &
,& '
null( ,
,, -
result. 4
.4 5
message5 <
,< =
result> D
.D E
errorMessageE Q
)Q R
;R S
var 
base64 
= 
GenerateExcelBase64 ,
(, -
result- 3
.3 4
report4 :
): ;
;; <
return 
( 
true 
, 
base64  
,! "
$str# 5
,6 7
null8 <
)< =
;= >
} 	
private!! 
string!! 
GenerateExcelBase64!! *
(!!* +
List!!+ /
<!!/ 0$
CommentCountByUserReport!!0 H
>!!H I

reportData!!J T
)!!T U
{"" 	
using## 
(## 
var## 
workbook## 
=##  !
new##" %

XLWorkbook##& 0
(##0 1
)##1 2
)##2 3
{$$ 
var%% 
	worksheet%% 
=%% 
workbook%%  (
.%%( )

Worksheets%%) 3
.%%3 4
Add%%4 7
(%%7 8
$str%%8 H
)%%H I
;%%I J
	worksheet'' 
.'' 
Cell'' 
('' 
$num''  
,''  !
$num''" #
)''# $
.''$ %
Value''% *
=''+ ,
$str''- 2
;''2 3
	worksheet(( 
.(( 
Cell(( 
((( 
$num((  
,((  !
$num((" #
)((# $
.(($ %
Value((% *
=((+ ,
$str((- 7
;((7 8
	worksheet)) 
.)) 
Cell)) 
()) 
$num))  
,))  !
$num))" #
)))# $
.))$ %
Value))% *
=))+ ,
$str))- 4
;))4 5
	worksheet** 
.** 
Cell** 
(** 
$num**  
,**  !
$num**" #
)**# $
.**$ %
Value**% *
=**+ ,
$str**- 5
;**5 6
	worksheet++ 
.++ 
Cell++ 
(++ 
$num++  
,++  !
$num++" #
)++# $
.++$ %
Value++% *
=+++ ,
$str++- <
;++< =
for-- 
(-- 
int-- 
i-- 
=-- 
$num-- 
;-- 
i--  !
<--" #

reportData--$ .
.--. /
Count--/ 4
;--4 5
i--6 7
++--7 9
)--9 :
{.. 
var// 
item// 
=// 

reportData// )
[//) *
i//* +
]//+ ,
;//, -
	worksheet00 
.00 
Cell00 "
(00" #
i00# $
+00% &
$num00' (
,00( )
$num00* +
)00+ ,
.00, -
Value00- 2
=003 4
item005 9
.009 :
UID00: =
;00= >
	worksheet11 
.11 
Cell11 "
(11" #
i11# $
+11% &
$num11' (
,11( )
$num11* +
)11+ ,
.11, -
Value11- 2
=113 4
item115 9
.119 :
UserName11: B
;11B C
	worksheet22 
.22 
Cell22 "
(22" #
i22# $
+22% &
$num22' (
,22( )
$num22* +
)22+ ,
.22, -
Value22- 2
=223 4
item225 9
.229 :
Email22: ?
;22? @
	worksheet33 
.33 
Cell33 "
(33" #
i33# $
+33% &
$num33' (
,33( )
$num33* +
)33+ ,
.33, -
Value33- 2
=333 4
item335 9
.339 :
Gender33: @
;33@ A
	worksheet44 
.44 
Cell44 "
(44" #
i44# $
+44% &
$num44' (
,44( )
$num44* +
)44+ ,
.44, -
Value44- 2
=443 4
item445 9
.449 :
CommentCount44: F
;44F G
}55 
	worksheet77 
.77 
Columns77 !
(77! "
)77" #
.77# $
AdjustToContents77$ 4
(774 5
)775 6
;776 7
using88 
(88 
var88 
stream88 !
=88" #
new88$ '
MemoryStream88( 4
(884 5
)885 6
)886 7
{99 
workbook:: 
.:: 
SaveAs:: #
(::# $
stream::$ *
)::* +
;::+ ,
var;; 
bytes;; 
=;; 
stream;;  &
.;;& '
ToArray;;' .
(;;. /
);;/ 0
;;;0 1
return<< 
Convert<< "
.<<" #
ToBase64String<<# 1
(<<1 2
bytes<<2 7
)<<7 8
;<<8 9
}== 
}>> 
}?? 	
}@@ 
}AA ‚
jC:\Users\BS01389\source\repos\SimpleBookStore\SimpleBookStore.BLL\Services\ReportService\IReportService.cs
	namespace 	
SimpleBookStore
 
. 
BLL 
. 
Services &
.& '
ReportService' 4
{ 
public 

	interface 
IReportService #
{ 
Task 
< 
( 
bool 
success 
, 
List  
<  !$
CommentCountByUserReport! 9
>9 :
report; A
,A B
stringC I
messageJ Q
,Q R
stringS Y
errorMessageZ f
)f g
>g h"
GetCommentCountByUsersi 
(	 Ä
)
Ä Å
;
Å Ç
Task		 
<		 
(		 
bool		 
success		 
,		 
List		  
<		  !
UserBookStatsReport		! 4
>		4 5
report		6 <
,		< =
string		> D
message		E L
,		L M
string		N T
errorMessage		U a
)		a b
>		b c
UserBookStats		d q
(		q r
)		r s
;		s t
Task

 
<

 
(

 
bool

 
success

 
,

 
string

 "
base64

# )
,

) *
string

+ 1
message

2 9
,

9 :
string

; A
errorMessage

B N
)

N O
>

O P'
DownloadCommentByUserReport

Q l
(

l m
)

m n
;

n o
} 
} «
cC:\Users\BS01389\source\repos\SimpleBookStore\SimpleBookStore.BLL\Services\LogService\LogService.cs
	namespace 	
SimpleBookStore
 
. 
BLL 
. 
Services &
.& '

LogService' 1
{ 
public 

class 

LogService 
: 
ILogService )
{ 
private		 
readonly		 
ILogRepository		 '
_logRepository		( 6
;		6 7
public

 
async

 
Task

 
	InsertLog

 #
(

# $
LogRequestModel

$ 3
logs

4 8
)

8 9
{ 	
var 
model 
= 
new 
Logs  
(  !
)! "
{ 
Success 
= 
logs 
. 
Success &
,& '
Message 
= 
logs 
. 
Message &
,& '
ErrorMessage 
= 
logs #
.# $
ErrorMessage$ 0
,0 1
	Createdby 
= 
$str $
,$ %
CreatedDate 
= 
DateTime &
.& '
UtcNow' -
.- .
AddHours. 6
(6 7
$num7 8
)8 9
} 
; 
await 
_logRepository  
.  !
	InsertLog! *
(* +
model+ 0
)0 1
;1 2
} 	
} 
} Ö
dC:\Users\BS01389\source\repos\SimpleBookStore\SimpleBookStore.BLL\Services\LogService\ILogService.cs
	namespace 	
SimpleBookStore
 
. 
BLL 
. 
Services &
.& '

LogService' 1
{ 
public 

	interface 
ILogService  
{ 
Task 
	InsertLog 
( 
LogRequestModel &
logs' +
)+ ,
;, -
}		 
}

 ÷
fC:\Users\BS01389\source\repos\SimpleBookStore\SimpleBookStore.BLL\Services\BookService\IBookService.cs
	namespace 	
SimpleBookStore
 
. 
BLL 
. 
Services &
.& '
BookService' 2
{ 
public 

	interface 
IBookService !
{		 
Task

 
<

 
List

 
<

 
Book

 
>

 
>

 
GetBookList

 $
(

$ %
)

% &
;

& '
Task 
< 
List 
< !
BookInfoResponseModel '
>' (
>( )
GetBookDetailInfo* ;
(; <
)< =
;= >
Task 
< 
( 
bool 
success 
, 
string "
message# *
,* +
string, 2
errorMessage3 ?
)? @
>@ A
BuyBookAsyncB N
(N O
BuyBookRequestModelO b
modelc h
)h i
;i j
Task 
< 
( 
bool 
success 
, 
string "
message# *
,* +
string, 2
errorMessage3 ?
)? @
>@ A$
ParseBooksFromExcelAsyncB Z
(Z [
	IFormFile[ d
filee i
)i j
;j k
} 
} ◊É
eC:\Users\BS01389\source\repos\SimpleBookStore\SimpleBookStore.BLL\Services\BookService\BookService.cs
	namespace 	
SimpleBookStore
 
. 
BLL 
. 
Services &
.& '
BookService' 2
{ 
public 

class 
BookService 
: 
IBookService +
{ 
private 
readonly 
IBookRepository (
_bookRepository) 8
;8 9
private 
readonly 
IReviewRepository *
_reviewRepository+ <
;< =
private 
readonly 
UserManager $
<$ %
User% )
>) *
_userManager+ 7
;7 8
private 
readonly 
IUserBookRepository ,
_userBookRepository- @
;@ A
private 
readonly 
ILogService $
_logService% 0
;0 1
private 
readonly 
IStoreUnitOfWork )
_storeUnitOfWork* :
;: ;
public 
BookService 
( 
IBookRepository *
bookRepository+ 9
,9 :
IReviewRepository 
reviewRepository .
,. /
UserManager 
< 
User 
> 
userManager )
,) *
IUserBookRepository 
userBookRepository  2
,2 3
ILogService 

logService "
," #
IStoreUnitOfWork 
storeUnitOfWork ,
), -
{ 	
_bookRepository   
=   
bookRepository   ,
;  , -
_reviewRepository!! 
=!! 
reviewRepository!!  0
;!!0 1
_userManager"" 
="" 
userManager"" &
;""& '
_userBookRepository## 
=##  !
userBookRepository##" 4
;##4 5
_logService$$ 
=$$ 

logService$$ $
;$$$ %
_storeUnitOfWork%% 
=%% 
storeUnitOfWork%% .
;%%. /
}&& 	
public(( 
async(( 
Task(( 
<(( 
List(( 
<(( 
Book(( #
>((# $
>(($ %
GetBookList((& 1
(((1 2
)((2 3
{)) 	
var** 
result** 
=** 
await** 
_bookRepository** .
.**. /
GetListAsync**/ ;
(**; <
)**< =
;**= >
return++ 
result++ 
;++ 
},, 	
public-- 
async-- 
Task-- 
<-- 
List-- 
<-- !
BookInfoResponseModel-- 4
>--4 5
>--5 6
GetBookDetailInfo--7 H
(--H I
)--I J
{.. 	
var// 
result// 
=// 
await// 
(//  
from//  $
b//% &
in//' )
_bookRepository//* 9
.//9 :
Get//: =
(//= >
)//> ?
join00  $
r00% &
in00' )
_reviewRepository00* ;
.00; <
Get00< ?
(00? @
)00@ A
on11  "
b11# $
.11$ %
Id11% '
equals11( .
r11/ 0
.110 1
BID111 4
join22  $
u22% &
in22' )
_userManager22* 6
.226 7
Users227 <
on33  "
r33# $
.33$ %
UID33% (
equals33) /
u330 1
.331 2
Id332 4
select44  &
new44' *!
BookInfoResponseModel44+ @
{55  !
Title66$ )
=66* +
b66, -
.66- .
Title66. 3
,663 4
Author77$ *
=77+ ,
b77- .
.77. /
Author77/ 5
,775 6
ISBN88$ (
=88) *
b88+ ,
.88, -
ISBN88- 1
,881 2
Price99$ )
=99* +
b99, -
.99- .
Price99. 3
,993 4
PublishDate::$ /
=::0 1
b::2 3
.::3 4
PublishedDate::4 A
.::A B
ToString::B J
(::J K
$str::K W
)::W X
,::X Y
Stock;;$ )
=;;* +
b;;, -
.;;- .
Stock;;. 3
,;;3 4
BookId<<$ *
=<<+ ,
b<<- .
.<<. /
Id<</ 1
,<<1 2
UserName==$ ,
===- .
u==/ 0
.==0 1
UserName==1 9
,==9 :
Email>>$ )
=>>* +
u>>, -
.>>- .
Email>>. 3
,>>3 4
UserId??$ *
=??+ ,
u??- .
.??. /
Id??/ 1
,??1 2
Rating@@$ *
=@@+ ,
r@@- .
.@@. /
Rating@@/ 5
,@@5 6
CommentAA$ +
=AA, -
rAA. /
.AA/ 0
CommentAA0 7
,AA7 8
ReviewIdBB$ ,
=BB- .
rBB/ 0
.BB0 1
IdBB1 3
}CC  !
)CC! "
.CC" #
ToListAsyncCC# .
(CC. /
)CC/ 0
;CC0 1
returnDD 
resultDD 
;DD 
}EE 	
publicFF 
asyncFF 
TaskFF 
<FF 
(FF 
boolFF 
successFF  '
,FF' (
stringFF) /
messageFF0 7
,FF7 8
stringFF9 ?
errorMessageFF@ L
)FFL M
>FFM N
BuyBookAsyncFFO [
(FF[ \
BuyBookRequestModelFF\ o
modelFFp u
)FFu v
{GG 	
returnHH 
awaitHH 
_storeUnitOfWorkHH )
.HH) *
CommitAsyncHH* 5
<HH5 6
(HH6 7
boolHH7 ;
,HH; <
stringHH= C
,HHC D
stringHHE K
)HHK L
>HHL M
(HHM N
asyncHHN S
(HHT U
)HHU V
=>HHW Y
{II 
varJJ 
bookInfoJJ 
=JJ 
awaitJJ $
_bookRepositoryJJ% 4
.JJ4 5
GetEntityAsyncJJ5 C
(JJC D
xJJD E
=>JJF H
xJJI J
.JJJ K
IdJJK M
==JJN P
modelJJQ V
.JJV W
BookIdJJW ]
)JJ] ^
;JJ^ _
ifLL 
(LL 
bookInfoLL 
isLL 
nullLL  $
)LL$ %
{MM 
awaitNN 
_logServiceNN %
.NN% &
	InsertLogNN& /
(NN/ 0
newOO 
LogRequestModelOO +
(OO+ ,
)OO, -
{PP 
SuccessPP !
=PP" #
falsePP$ )
,PP) *
MessageQQ !
=QQ" #
$strQQ$ 4
,QQ4 5
ErrorMessageRR &
=RR' (
stringRR) /
.RR/ 0
FormatRR0 6
(RR6 7
$strRR7 f
+RRg h
$strSS 2
,SS3 4
modelSS5 :
.SS: ;
BookIdSS; A
,SSA B
modelSSB G
.SSG H
UserIdSSH N
)SSN O
}TT 
)TT 
;TT 
returnUU 
(UU 
falseUU !
,UU! "
$strUU# 3
,UU3 4
$strUU5 ]
)UU] ^
;UU^ _
}VV 
elseXX 
ifXX 
(XX 
bookInfoXX !
.XX! "
StockXX" '
==XX( *
$numXX+ ,
)XX, -
{YY 
awaitZZ 
_logServiceZZ %
.ZZ% &
	InsertLogZZ& /
(ZZ/ 0
new[[ 
LogRequestModel[[ +
([[+ ,
)[[, -
{\\ 
Success]] #
=]]$ %
false]]& +
,]]+ ,
Message^^ #
=^^$ %
$str^^& K
,^^K L
ErrorMessage__ (
=__) *
string__+ 1
.__1 2
Format__2 8
(__8 9
$str__9 h
+__i j
$str`` 4
,``4 5
model``6 ;
.``; <
BookId``< B
,``B C
model``D I
.``I J
UserId``J P
)``P Q
}aa 
)aa 
;aa 
returnbb 
(bb 
falsebb !
,bb! "
$strbb# H
,bbH I
nullbbJ N
)bbN O
;bbO P
}cc 
varee 
insertModelee 
=ee  !
newee" %
	User_Bookee& /
(ee/ 0
)ee0 1
{ff 
BookIdgg 
=gg 
modelgg "
.gg" #
BookIdgg# )
,gg) *
UserIdhh 
=hh 
modelhh "
.hh" #
UserIdhh# )
}ii 
;ii 
varkk 
resultkk 
=kk 
awaitkk "
_userBookRepositorykk# 6
.kk6 7
InsertAsynckk7 B
(kkB C
insertModelkkC N
)kkN O
;kkO P
ifmm 
(mm 
!mm 
resultmm 
.mm 
successmm #
)mm# $
{nn 
awaitoo 
_logServiceoo %
.oo% &
	InsertLogoo& /
(oo/ 0
newpp 
LogRequestModelpp *
(pp* +
)pp+ ,
{qq 
Successrr "
=rr# $
falserr% *
,rr* +
Messagess "
=ss# $
$strss% 5
,ss5 6
ErrorMessagett '
=tt( )
stringtt* 0
.tt0 1
Formattt1 7
(tt7 8
$str	tt8 â
,uu 
modeluu "
.uu" #
BookIduu# )
,uu) *
modeluu+ 0
.uu0 1
UserIduu1 7
,uu7 8
resultuu9 ?
.uu? @
errorMessageuu@ L
)uuL M
}vv 
)vv 
;vv 
returnww 
(ww 
falseww !
,ww! "
resultww# )
.ww) *
messageww* 1
,ww1 2
resultww3 9
.ww9 :
errorMessageww: F
)wwF G
;wwG H
}xx 
bookInfozz 
.zz 
Stockzz 
-=zz  "
$numzz# $
;zz$ %
_bookRepository{{ 
.{{  
Update{{  &
({{& '
bookInfo{{' /
){{/ 0
;{{0 1
return}} 
(}} 
true}} 
,}} 
$str}} ;
,}}; <
null}}= A
)}}A B
;}}B C
}~~ 
)~~ 
;~~ 
} 	
public
ÄÄ 
async
ÄÄ 
Task
ÄÄ 
<
ÄÄ 
(
ÄÄ 
bool
ÄÄ 
success
ÄÄ  '
,
ÄÄ' (
string
ÄÄ) /
message
ÄÄ0 7
,
ÄÄ7 8
string
ÄÄ9 ?
errorMessage
ÄÄ@ L
)
ÄÄL M
>
ÄÄM N&
ParseBooksFromExcelAsync
ÄÄO g
(
ÄÄg h
	IFormFile
ÄÄh q
file
ÄÄr v
)
ÄÄv w
{
ÅÅ 	
var
ÇÇ 
books
ÇÇ 
=
ÇÇ 
new
ÇÇ 
List
ÇÇ  
<
ÇÇ  !
Book
ÇÇ! %
>
ÇÇ% &
(
ÇÇ& '
)
ÇÇ' (
;
ÇÇ( )
if
ÑÑ 
(
ÑÑ 
file
ÑÑ 
==
ÑÑ 
null
ÑÑ 
||
ÑÑ 
file
ÑÑ  $
.
ÑÑ$ %
Length
ÑÑ% +
==
ÑÑ, .
$num
ÑÑ/ 0
)
ÑÑ0 1
{
ÖÖ 
await
ÜÜ 
_logService
ÜÜ !
.
ÜÜ! "
	InsertLog
ÜÜ" +
(
ÜÜ+ ,
new
áá 
LogRequestModel
áá $
(
áá$ %
)
áá% &
{
àà 
Success
ââ 
=
ââ 
false
ââ $
,
ââ$ %
Message
ää 
=
ää 
$str
ää P
,
ääP Q
ErrorMessage
ãã !
=
ãã" #
$str
ãã$ x
,
ããx y
}
åå 
)
åå 
;
åå 
return
çç 
(
çç 
false
çç 
,
çç 
$str
çç 5
,
çç5 6
$str
çç7 L
)
ççL M
;
ççM N
}
éé 
using
êê 
(
êê 
var
êê 
stream
êê 
=
êê 
new
êê  #
MemoryStream
êê$ 0
(
êê0 1
)
êê1 2
)
êê2 3
{
ëë 
await
íí 
file
íí 
.
íí 
CopyToAsync
íí &
(
íí& '
stream
íí' -
)
íí- .
;
íí. /
using
ìì 
(
ìì 
var
ìì 
workbook
ìì #
=
ìì$ %
new
ìì& )

XLWorkbook
ìì* 4
(
ìì4 5
stream
ìì5 ;
)
ìì; <
)
ìì< =
{
îî 
var
ïï 
	worksheet
ïï !
=
ïï" #
workbook
ïï$ ,
.
ïï, -
	Worksheet
ïï- 6
(
ïï6 7
$num
ïï7 8
)
ïï8 9
;
ïï9 :
var
ññ 
rows
ññ 
=
ññ 
	worksheet
ññ (
.
ññ( )
	RangeUsed
ññ) 2
(
ññ2 3
)
ññ3 4
.
ññ4 5
RowsUsed
ññ5 =
(
ññ= >
)
ññ> ?
.
ññ? @
Skip
ññ@ D
(
ññD E
$num
ññE F
)
ññF G
;
ññG H
foreach
òò 
(
òò 
var
òò  
row
òò! $
in
òò% '
rows
òò( ,
)
òò, -
{
ôô 
var
öö 
book
öö  
=
öö! "
new
öö# &
Book
öö' +
{
õõ 
Title
úú !
=
úú" #
row
úú$ '
.
úú' (
Cell
úú( ,
(
úú, -
$num
úú- .
)
úú. /
.
úú/ 0
	GetString
úú0 9
(
úú9 :
)
úú: ;
,
úú; <
Author
ùù "
=
ùù# $
row
ùù% (
.
ùù( )
Cell
ùù) -
(
ùù- .
$num
ùù. /
)
ùù/ 0
.
ùù0 1
	GetString
ùù1 :
(
ùù: ;
)
ùù; <
,
ùù< =
ISBN
ûû  
=
ûû! "
row
ûû# &
.
ûû& '
Cell
ûû' +
(
ûû+ ,
$num
ûû, -
)
ûû- .
.
ûû. /
	GetString
ûû/ 8
(
ûû8 9
)
ûû9 :
,
ûû: ;
Price
üü !
=
üü" #
decimal
üü$ +
.
üü+ ,
TryParse
üü, 4
(
üü4 5
row
üü5 8
.
üü8 9
Cell
üü9 =
(
üü= >
$num
üü> ?
)
üü? @
.
üü@ A
	GetString
üüA J
(
üüJ K
)
üüK L
,
üüL M
out
üüN Q
var
üüR U
price
üüV [
)
üü[ \
?
üü] ^
price
üü_ d
:
üüe f
$num
üüg h
,
üüh i
PublishedDate
†† )
=
††* +
DateTime
††, 4
.
††4 5
TryParse
††5 =
(
††= >
row
††> A
.
††A B
Cell
††B F
(
††F G
$num
††G H
)
††H I
.
††I J
	GetString
††J S
(
††S T
)
††T U
,
††U V
out
††W Z
var
††[ ^
date
††_ c
)
††c d
?
††e f
date
††g k
:
††l m
DateTime
††n v
.
††v w
MinValue
††w 
,†† Ä
	Createdby
°° %
=
°°& '
Constant
°°( 0
.
°°0 1
Role
°°1 5
.
°°5 6

SuperAdmin
°°6 @
,
°°@ A
CreatedDate
¢¢ '
=
¢¢( )
DateTime
¢¢* 2
.
¢¢2 3
UtcNow
¢¢3 9
.
¢¢9 :
AddHours
¢¢: B
(
¢¢B C
$num
¢¢C D
)
¢¢D E
}
££ 
;
££ 
books
•• 
.
•• 
Add
•• !
(
••! "
book
••" &
)
••& '
;
••' (
}
¶¶ 
}
ßß 
}
®® 
return
™™ 
await
™™ 
_storeUnitOfWork
™™ )
.
™™) *
CommitAsync
™™* 5
<
™™5 6
(
™™6 7
bool
™™7 ;
,
™™; <
string
™™= C
,
™™C D
string
™™E K
)
™™K L
>
™™L M
(
™™M N
async
™™N S
(
™™T U
)
™™U V
=>
™™W Y
{
´´ 
var
¨¨ 
result
¨¨ 
=
¨¨ 
await
¨¨ "
_bookRepository
¨¨# 2
.
¨¨2 3
InsertRangeAsync
¨¨3 C
(
¨¨C D
books
¨¨D I
)
¨¨I J
;
¨¨J K
return
≠≠ 
(
≠≠ 
result
≠≠ 
.
≠≠ 
success
≠≠ &
,
≠≠& '
result
≠≠( .
.
≠≠. /
message
≠≠/ 6
,
≠≠6 7
result
≠≠8 >
.
≠≠> ?
errorMessage
≠≠? K
)
≠≠K L
;
≠≠L M
}
ÆÆ 
)
ÆÆ 
;
ÆÆ 
}
ØØ 	
}
±± 
}≤≤ «
fC:\Users\BS01389\source\repos\SimpleBookStore\SimpleBookStore.BLL\Configurations\DependencyResolver.cs
	namespace		 	
SimpleBookStore		
 
.		 
BLL		 
.		 
Configurations		 ,
{

 
public 

static 
class 
DependencyResolver *
{ 
public 
static 
IServiceCollection (
BLL) ,
(, -
this- 1
IServiceCollection2 D
servicesE M
,M N
IConfigurationO ]
configuration^ k
)k l
{ 	
services 
. 
	AddScoped 
< 
IUserService +
,+ ,
UserService, 7
>7 8
(8 9
)9 :
;: ;
services 
. 
	AddScoped 
< 
IReportService -
,- .
ReportService. ;
>; <
(< =
)= >
;> ?
services 
. 
	AddScoped 
< 
IBookService +
,+ ,
BookService, 7
>7 8
(8 9
)9 :
;: ;
services 
. 
	AddScoped 
< 
IReviewService -
,- .
ReviewService. ;
>; <
(< =
)= >
;> ?
services 
. 
	AddScoped 
< 
ILogService *
,* +

LogService+ 5
>5 6
(6 7
)7 8
;8 9
return 
services 
; 
} 	
} 
} 