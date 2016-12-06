using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.day6
{
    public class Day6
    {

        private const string Input = "yyzfkpnq\r\njywprukn\r\nwsovudpi\r\nxrexczjp\r\nlxxexnke\r\nyzcrsvfl\r\nhfmjylbr\r\nechansea\r\nsoqtipnu\r\nkcczgkjs\r\ntkxqkyvb\r\ncphlzynq\r\nmlpbiksm\r\nzsyekvjv\r\nxxzxstxx\r\nbvqgygvh\r\ndtxnlzib\r\nunukvrmw\r\nszarrcqn\r\nzpovpibu\r\nigmwyioj\r\norausztk\r\nzguoanfz\r\nuwcamvjp\r\nijlzaeyb\r\nthwdcryp\r\nzcwxmdxc\r\njwrmtdbx\r\nzqxyrskh\r\nufoohfap\r\naodyaarr\r\nmxcbalhx\r\ntzpyurir\r\nnxxpdfso\r\nocioakza\r\nymsuqgzy\r\nuzsfureu\r\nmotqekjl\r\ncnfrigwc\r\nqorjiulb\r\nrbsixwqi\r\nptxfbmef\r\njhwopfrl\r\nugcsqhom\r\nmkomobos\r\nwbcexznu\r\nimpsluue\r\nebojtrvp\r\nmscyhvwe\r\njnnjykgz\r\nicobfeeh\r\nqscuwdkx\r\nozeilhke\r\nbtrlvsog\r\nsfewiwzr\r\ntptfsoru\r\nmlpzsmqf\r\nerrxvttw\r\nkqgynlka\r\nfujmsmjp\r\ncufdkgyi\r\nqfqotxvy\r\nbhytijml\r\naueqkddy\r\ncnbxutls\r\nlsmsdgra\r\nndjqohpk\r\ntxncbjvv\r\ndrvgidhf\r\nhlifeweo\r\nznxeddna\r\nfdugqlii\r\nbcjwnjyl\r\nidrjqtmr\r\ngechofdk\r\nvqriafnm\r\njkaoskuf\r\nlqidragl\r\nkktqqqcy\r\nuqihlagh\r\ncslabmoa\r\nhaztkzfl\r\ndtzxfuud\r\nyusadhzr\r\nlyjwyywa\r\nkqkioixv\r\nfernopuc\r\ncgeswuhf\r\njbikrerm\r\nrnvgflse\r\nurqvfxqs\r\nogbjxnqh\r\nypfjnogw\r\nszeszjfw\r\nddggwcrc\r\niisvlkaz\r\nctnmxreg\r\nstyixlfp\r\nbmtulfok\r\ntjatbqpv\r\nsbqtefuj\r\nbxdqezrg\r\nenqwugon\r\npalqwsdx\r\nhtgethby\r\nkqzqkhom\r\nfxpyogvx\r\npcggwrmq\r\nbexolzrd\r\ntyhzuxrj\r\nrnpxgwtp\r\nrjassgcj\r\nzaepiryv\r\ngueppvdl\r\nvrvhxyak\r\nzzjfaxiq\r\nofvwgjsb\r\nwljxbsww\r\nzadwiivt\r\ntdjtsqoa\r\nphmsorex\r\nhjyjitfq\r\nmxivbtuo\r\nvgwnrdkh\r\nuiuxqiar\r\nlyfqhikf\r\nsldnbsee\r\nnakjrqrv\r\nyzpptezp\r\ndtnlnoii\r\nsgcxoemt\r\nmxuxcjds\r\nfzbawcuk\r\nwpslbtdo\r\nfvhfvsuy\r\nfgjpefjn\r\nxnlfkcnv\r\nitucclph\r\nfuuxuiqh\r\nqgtbjfgw\r\nzakxlysq\r\nsrmwofsh\r\ndtjvuhtn\r\nfmhinrkc\r\neyxffjqy\r\nbqjdculb\r\nhvfdufhz\r\ncwaukzzq\r\npmqtvpfu\r\nseuyiwht\r\njcdyawhy\r\naljrcshh\r\ngmehbldw\r\njsgzroht\r\nvjyysjjy\r\nnjbmtbna\r\natqmtjcc\r\nxlakorgr\r\ndsgvcmer\r\ngpiisgfj\r\njlycgznr\r\nwxhsfonh\r\nsgphbiye\r\nbhfcrvsd\r\nvvyfxygk\r\nkpwedksb\r\nsudyedgh\r\nhyydhspc\r\nuokepeon\r\nioecgpbw\r\nlkmutdjy\r\npshtrmmz\r\nkroueprw\r\nxwublsln\r\ndavbfiem\r\nwippdcas\r\ncnnjktjt\r\njtgcztya\r\nnbdutcpk\r\nlebebegl\r\nbyswsvmu\r\ndvrhjnmz\r\ngzvwdqxu\r\ngmpfpixt\r\neetccbqc\r\nwxbzmtyz\r\nnfpuhahj\r\nkpzblmgq\r\nauypcthp\r\nluanyjde\r\npwmbrsxh\r\nyugkpuhc\r\nzvlglwne\r\nrdtbnymo\r\nypbdveag\r\nuxetfzxi\r\nlvxhqpug\r\ncmakitao\r\nnfpuvcpi\r\nnyrdursy\r\nbmnxqdmg\r\ntggaqphx\r\nebqocwik\r\nlppmevzv\r\nlvnmmcfl\r\nmgjsjqln\r\nvwmttobw\r\nahmdkmia\r\nmxetfwxi\r\nxrwduudz\r\nhqnkjlvq\r\nglrtsjyr\r\nkprkzuvv\r\ncjtganjz\r\nooaqzdxk\r\nlxoaviio\r\nhslnkxup\r\npfygvskj\r\nfugthgms\r\nmwogejct\r\nnybvncbz\r\nrfwrzyjd\r\nfwbyjkhr\r\ncmfogvwt\r\npwpnplfa\r\njoxmcaeh\r\nwhyxmnvf\r\ncgduliyz\r\ndxdyzfpq\r\nzbqlcuwk\r\nfirflzbq\r\nxdghelzh\r\ncznfxohv\r\nrdaufnnr\r\nzsgcalag\r\njrzjuidq\r\nyawkpcsf\r\nheloyror\r\nuldiwqpw\r\nokpydgfc\r\naytjeofw\r\nxnfwzlez\r\nnneorzjx\r\nrdwjvmta\r\nainwxnas\r\ntnkmegab\r\niwiuhpmk\r\nedekyxip\r\nkxxvmlhk\r\nudferwsa\r\nvyhaapmd\r\nmtmnqzpg\r\nptzohtzv\r\nefhufnnz\r\nurdkdyzh\r\nyjnouvbd\r\nthclkscb\r\nmmvdjtte\r\ndsivsdkp\r\nommazwht\r\nqcwdqhzk\r\nqigvygwa\r\njvntlbmd\r\nqpxgkfdb\r\nnqasdieh\r\nnffhnuvj\r\nqixcnwly\r\nuichhhgl\r\npzpqdbyu\r\nwcngjzsk\r\nejugtmos\r\njbyxfsix\r\noqckcobc\r\ntvnxlkvt\r\nrrlggecb\r\nsfyhlmkn\r\nnadikadl\r\njeubkdbq\r\ngonkgvab\r\nxzskvofy\r\nibapazlb\r\ngpqcgned\r\nlvskmblm\r\nvochfalb\r\nuzzrcljz\r\nfuhnzlss\r\nkgqrvfog\r\nxtctngmk\r\nfkopdbku\r\nejhopiqg\r\nbhjuiikq\r\ndphnscrm\r\nutvwdorg\r\nhjrgjfth\r\nlfzygyyy\r\nqnkxyxlm\r\niwiffosx\r\nqouzchvg\r\nhvwqvxhw\r\nnczbpucj\r\ntgdsahph\r\nccvsxnpb\r\nzqykmxbs\r\ngfsswdut\r\njeiyknwo\r\nrahvwzmr\r\nyonmgbxi\r\nnwuczfdr\r\njiispjyn\r\ngehydavl\r\nghvlnljs\r\ngaerupxc\r\nobjzhajd\r\nqsibzaum\r\nxhbojnbs\r\nnykwucum\r\nprgabpch\r\nhezzgeoc\r\nsxiqogzh\r\ntuskyutg\r\nlgafyodf\r\njxvvrjwx\r\noebuabir\r\nqvdbbfrn\r\njplrzdjt\r\npqkpjdnc\r\nwcmnokpx\r\nqfoyxeax\r\nyfyvprce\r\nxojmqboi\r\njvfmcxjn\r\npslauuvt\r\nvlvrizqg\r\nqgzirvqv\r\nvrkqfuwf\r\nhhtinail\r\nioecucue\r\nqshkemzo\r\nylseohek\r\nsvaqebui\r\ntakjrpnu\r\nhrvqhlue\r\nenumsbdx\r\nwaosyzfe\r\nouzibadf\r\nylqzlhsr\r\nxesfwpcp\r\nmkseaapu\r\nixpyzdke\r\nkftxpmgd\r\nwcbrqrua\r\niclrctfo\r\npguazprz\r\nelgvmzmz\r\ndguzpmar\r\nqaovgsxm\r\nhjxaakpz\r\nrumgmqwf\r\npilipgru\r\newtrmfjc\r\nnsdeomwi\r\naucrjgzq\r\nebyrdicj\r\nbvcacqtz\r\nwjfustty\r\nsaahqqzi\r\nkogwimsb\r\nfhbtgnao\r\nofqowitr\r\nrdnvwowd\r\naytcydvg\r\nbmtljhdw\r\ncjmtqcwm\r\nvjepjxnx\r\nfojibpga\r\nnpawksib\r\nqkjaqrhz\r\ndszkawfz\r\nidqccfnn\r\nyqtgayil\r\nufrqxrtj\r\nmvecaukm\r\nvkteopvi\r\ndhfwwylt\r\nigkbfhdx\r\nzdvllwsn\r\nhsedlmnd\r\napmcophg\r\nyllwzjmu\r\ngdzzyeqi\r\nrzyqtoig\r\nxjolcltb\r\nixxzpqlv\r\nsynujyzi\r\numervtrw\r\nxysbjydr\r\nyeywrrxc\r\ntzgnewzc\r\nvnphmnze\r\nkkudnbkf\r\njqphaagv\r\nztlmyhmw\r\nmhbbring\r\nvlpnmzaq\r\nghwuixap\r\nwktiwnpx\r\nrbugtbqz\r\nkkhedbnt\r\nbryeqkmb\r\nwcdnhcij\r\nuhxixbol\r\nndkswawo\r\nlrzovgcw\r\nafihkyxc\r\nwkzpodee\r\ntqrmfacs\r\nwlyxwgor\r\nyeitnczn\r\nbnozzykq\r\nqoxrnjqc\r\nxbzodqck\r\nwzyrtfqt\r\nodnhhbdl\r\nkdblluxl\r\nxzoerezu\r\nvwrpwvle\r\nlnahdnuf\r\nkwrnedhq\r\nfbwprhhf\r\ndkgycbqn\r\nkmjajkda\r\nfzrwjkaa\r\navytimci\r\nayrsdhtp\r\nmeffhxoo\r\nghqbnvby\r\noggqytlo\r\nojtdckks\r\ngtbjgqfx\r\njqkupaek\r\ncmdzqfdo\r\nsmargvov\r\nsavskjrm\r\nzilzpxgd\r\nzqfktwjf\r\nrsarxelu\r\nodtqqnlp\r\nfbwxjvvd\r\nyqclkrat\r\ngmmmdrye\r\nqijqvzbj\r\nragmubct\r\ngffgtluf\r\nhiqkmiom\r\nprxgwyii\r\nxamwdlld\r\ngavpfbxs\r\nmpkfilwo\r\nvvozqkfu\r\nccbdvzuy\r\nduzvfxdp\r\nqcvsbeys\r\nakbhjcyp\r\ndnplpcqs\r\nbzvajkkv\r\nyionjich\r\nvlhrivqa\r\neklqhjwt\r\nzlhmwatm\r\neiiueoct\r\nzbcztogj\r\nmsxwmbsg\r\ndpdvhoqc\r\ngwljnfuo\r\nalszfqbn\r\nkzwbfcxt\r\nirjfsuod\r\nljebgqjd\r\ndklfwjbk\r\ntscvzkko\r\nwvwcplpd\r\niewadhyw\r\nqwngxyeo\r\nshklqqvu\r\nhduiuhsf\r\nbinjsify\r\npuapudwl\r\npiszohps\r\nrccnzrrn\r\nhocsgqvh\r\nvnodhywj\r\nlmtmroeq\r\nekqammsw\r\nlwqbipzs\r\nbwhuyeby\r\nowwozald\r\nnowfwxnn\r\nooadouba\r\npldmnaww\r\nsumhyutk\r\ncxenygty\r\nnqnjcwxg\r\nveklrmyv\r\nffvimwbo\r\nwywlhsav\r\ncqgnbbhj\r\nmajlpxbs\r\niysdvxxd\r\ncnsunofx\r\neixebniw\r\nzpvyhttp\r\nftrbqnif\r\nddttvdyl\r\nfwdxaniy\r\nurbatveb\r\nfijbgypg\r\nickimqxl\r\nqcwavurw\r\nmkmdbtsj\r\nkwllaxge\r\nivlmxsgs\r\nqmxgfqnu\r\nrxovletq\r\ntvdtiipz\r\nwqaeqspc\r\nxzfkxkqn\r\nxbhqxste\r\nghfneagv\r\nepiemcmq\r\nqyseovqi\r\nrapjeyxj\r\nvbnlgjfv\r\nkyqcxmls\r\ndlzyyaqt\r\ntbbjzwqj\r\nmizphxvx\r\npamlbpte\r\nrevcferf\r\noouedwik\r\nymbatasm\r\naeszvcca\r\nteirneaq\r\nacrluwwg\r\nytoountd\r\nhpxikugi\r\nhmmoncon\r\naiktuico\r\ndklpihab\r\nmphjokkv\r\nueocpnry\r\nbulrjcvm\r\nnrsegeao\r\ncflobpzl\r\nsivytxsq\r\nsjvzthwm\r\nltkxmvel\r\nwmgoysrp\r\nnrgjyvcn\r\nusdpstyb\r\nzefhvtmr\r\nvlqhpkup\r\nkukdtoyj\r\nobyhxscm\r\neoecwepi\r\nxkqcqpif\r\nxtupijxg\r\nhjbfeqgp\r\nohskaxva\r\nacimoqlz\r\nbvmbrwii\r\ngohlekof\r\nbgrnzyxm\r\nrstnmucn\r\nxbbskwej\r\nwhzvzyww\r\nudtsgqax\r\noqcwhggu\r\nzuikbmbc\r\nbnqieolu\r\nlzkdsxef\r\npxfzsrkk\r\naddllsuq\r\nctmpeffv\r\nayuymejt\r\nrubisjfv\r\nkyiawgye\r\npbrejbnc\r\neiiplpud\r\nvhfjnrzy\r\nyjjnxvbm\r\neapstgjd\r\njtffvmmo\r\ntjkdxvlu\r\nrjuchthb\r\nvrhioetj\r\ntwwvmogj\r\ninfjgjpu\r\nlgkgbzyx";
        private const int InputStringLength = 8;
        private const string Input2 = "eedadn\r\ndrvtee\r\neandsr\r\nraavrd\r\natevrs\r\ntsrnev\r\nsdttsa\r\nrasrtv\r\nnssdts\r\nntnada\r\nsvetve\r\ntesnvt\r\nvntsnd\r\nvrdear\r\ndvrsen\r\nenarar";
        public static void Main(string[] args)
        {
            List<Dictionary<char, int>> list = new List<Dictionary<char, int>>();
            foreach (string input in Input.Split(new[] {"\r\n"}, StringSplitOptions.None))
            {
                for (int i = 0; i < InputStringLength; i++)
                {
                    if (list.Count <= i)
                    {
                        list.Add(new Dictionary<char, int>());
                    }
                    else
                    {
                        Dictionary<char, int> d = list[i];
                    }
                    Dictionary<char, int> dict = list[i];
                    if (dict.ContainsKey(input[i]))
                    {
                        dict[input[i]] += 1;
                    }
                    else
                    {
                        dict.Add(input[i], 1);
                    }
                }   
            }
            CalculateDay1(list);
            Console.WriteLine("----");
            CalculateDay2(list);
        }

        private static void CalculateDay2(List<Dictionary<char, int>> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Dictionary<char, int> dict = list[i];
                KeyValuePair<char, int> currentPair = dict.First();
                foreach (KeyValuePair<char, int> kvp in dict)
                {
                    if (kvp.Value < currentPair.Value)
                    {
                        currentPair = kvp;
                    }
                }
                Console.WriteLine("Char [" + i + "]: " + currentPair.Key + " (" + currentPair.Value + ")");
            }
        }

        private static void CalculateDay1(List<Dictionary<char, int>> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Dictionary<char, int> dict = list[i];
                KeyValuePair<char, int> currentPair = dict.First();
                foreach (KeyValuePair<char, int> kvp in dict)
                {
                    if (kvp.Value > currentPair.Value)
                    {
                        currentPair = kvp;
                    }
                }
                Console.WriteLine("Char [" + i + "]: " + currentPair.Key + " (" + currentPair.Value + ")");
            }
        }
    }
}
