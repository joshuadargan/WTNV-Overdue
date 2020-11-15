using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectible : MonoBehaviour
{
    public static string[] Lore = new string[] {
        //Public Library Information
        "The Biography section contains nothing but 33 copies of the official biography of Helen Hunt.",
        "Citizens found themselves in the library by waking up between two shelves in a dizzy haze, unsure of how they got there, and then wandering around, trapped, until they wake with a start in their own beds, covered with sweat, and with a few books they checked out on their nightstand.",
        "Librarian repellent dispensers have been placed throughout the building for the safety of the visitors.",
        "The library is run by a group of malevolent Librarians (who are all named Randall) which the Night Vale citizens are encouraged to be cautious of.",
        "The Librarians offer amnesty for a variety of crimes to anyone willing to visit the library. This is most likely a front, though.",
        "Posters advertising the Summer Reading Program from 2013. All with the tagline 'Catch the flesh-eating reading bacterium!'",
        "You are going to get inside this book, and we are going to close it on you and there is nothing you can do about it.",
        "We are going to force you into a good book this summer.",
        "During the 2013 program, fourteen students between the ages of 5 and 17 were kidnapped by Librarians and trapped in the library. The number later grew to nearly 100 children and teens before the program officially began that day. It was during this event that Tamika Flynn, 12-years-old at the time, battled Librarians for the first time. Her triumph established her combat and leadership skills, and the severed head of the Librarian served as a reminder of her battle.",
        // Cecil Quotes
        "Did you know there's a faceless old woman who secretly lives in your home? It's true. She's there now. She's always there, just out of your sight. Always just out of your sight.", // Faceless Old Woman Who Secretly Lives in Your Home
        "The past is gone, and cannot harm you anymore. And while the future is fast coming for you, it always flinches first and settles in as the gentle present.",
        "Excerpt from changes to the Night Vale School District: In addition to the current foreign language offerings of Spanish, French, and Modified Sumerian, schools will now be offering Double Spanish, Weird Spanish, Coptic Spanish, Russian, and Unmodified Sumerian.", // EP5 The Shape in Grove Park
        // Town Events (Paraphrased)
        "Vote today! If you don't have time to make it to the polling places, in a pinch you can just raise your hand for your mayoral candidate. The cameras everywhere in town will count it.",
        "It's electrion season again! Please stand by for the Sheriff's Secret Police to collect certain family members so that everyone votes for the correct council seats and there's no confusion.", // EP4 PTA Meeting
        // Proverbs
        "There's a special place in Hell. It's really hip. Very exclusive.",                                                                                // EP3 Station Management
        "A million dollars isn’t cool. You know what’s cool? A basilisk.",                                                                                  // EP5 The Shape in Grove Park
        "It must be 3:23 PM somewhere. Maybe space?",                                                                                                       // EP7 History Week
        "Today is the last day of your life up to this point.",                                                                                             // EP11 Wheat & Wheat By-Products
        "Biologically speaking, we are all people made up of smaller people.",                                                                              // EP14 The Man in the Tan Jacket
        "If I said you had a beautiful body, would it even matter because we are so insignificant in this vast incomprehensible universe?",                 // EP16 The Phone Call
        "Step one: write down the names of everyone you know. Step two: rearrange the letters. Step three: this will reveal a great secret of time.",       // EP19A The Sandstorm (Part A)
        "Step one: separate your lips. Step two: use facial muscles to pull back corners of mouth. Step three: widen your eyes. This is how to be happy.",  // EP19B The Sandstorm (Part B)
        "Pain is just weakness leaving the body, and then being replaced by pain. Lots of pain.",                                                           // EP20 Poetry Week
        "Mamas, don’t let your babies grow up to be cowboys. Show them pictures of cows when they’re young and administer brief electrical shocks.",        // EP23 Eternal Scouts
        "The human soul weighs 21 grams, smells like grilled vegetables, looks like a wrinkled tartan quilt, and sounds like bridge traffic.",              // EP26 Faceless Old Woman
        "A bar walks into a bar. The bartender is a snake eating its own tail. The windows look out only onto the face of the one who looks.",              // EP28 Summer Reading Program
        "Thank you for your interest in a life free of pain. We're not accepting applications at this time. Please try again. And again. And again. And again. And again. And again. And again. And again.",    // EP34 A Beautiful Dream
        "Look. Up in the sky. It's a bird. It's a plane. No. It's just the void. Infinite and indifferent. We're so small. So very very small.",            // EP36 Missing
        "A journey of a thousand miles begins with a single command from a satellite-activated mind control chip.",                                         // EP38 Orange Grove
        "Ignore all the haters telling you that everything isn't a sandwich. Everything is a sandwich.",                                                    // EP42 Numbers ;_;
        "You won't sleep when you're dead, either.",                                                                                                        // EP43 Visitor
        "At your smallest components, you are indistinguishable from a forest fire.",                                                                       // EP44 Cookies
        "If you love something, set it free. If it starts flying around and chirping, it was probably a bird.",                                             // EP46 Parade Day
        "Feeling lost? Like you have no goal in life? Like you're covered in dirt and wet leaves? Like you're an earthworm? Are you an earthworm? Kinda sounds like you're an earthworm, actually.",            // EP48 Renovations
        "Everything that happens, happens for a reason. Except ostriches. What the hell man?",                                                              // EP51 Rumbling
        "Most people think pitbulls are dangerous dogs; but, biologically speaking, most pitbulls are just three Shih Tzu's wearing a trench coat.",        // EP52 The Retirement of Pamela Winchell
        "Language will evolve irregardless of your attempt to literally lock it away in a secluded tower, obvs.",                                           // EP55 The University of What It Is
        "If you're worried your writing isn't good just remember the earth is warming and soon good and bad writing alike will all be underwater.",         // BONUSEP1 Minutes
        "Beware of Greeks bearing gifts. Also beware of gifts of Greek bears. Gifted and bare Greeks are totally okay.",                                    // EP57 The List
        "If you want a picture of the future, imagine a person writing headlines about millennials forever.",                                               // EP59 Antiques
        "When you wish upon a star, your dreams come true. But, because of distance, not for millions of years.",                                           // EP66 worms...
        "Don’t be afraid of the dark. Be afraid of the terrible things that are hiding in there, and the terrible things they will do.",                    // EP68 Faceless Old Women
        "A rose by any other name is called something else.",                                                                                               // EP70a Taking Off
        "I'm a single issue voter. If the candidate is not a baby polar bear, I straight up cannot support them.",                                          // EP77 A Stranger
        "Be careful what you wish for. Because it probably won't come true, and life is about expectations management.",                                    // EP82 Skating Rink
        "Writing rules: 1) Write a lot. 2) Read a lot. 3) If someone tells you not to use adverbs or some other Elmore Leonard thing, swiftly kick them.",  // EP92 If He Had Lived
        "The children were right. The floor is lava. But they were wrong about the heat resistance of sofa cushions.",                                      // EP96 Negotiations
        "Good thing come to those who wait. Good things come slithering down the unctuous brown stone walls to those who wait alone in the dark pit.",      // EP106 Filings
        "You'll catch more flies with honey than with vinegar, but you'll catch even more with a corpse of some sort.",                                     // EP108 Cal
        "If you only read one book this year, then you have reached your approved book quota.",                                                             // EP110 Matryoshka
        "There is no proof you exist, only evidence.",                                                                                                      // EP111 Summer 2017, Night Vale, USA
        "Be yourself... as if you had any choice in the matter.",                                                                                           // EP112 Citizen Spotlight
        "People always say \"before I die\" as if they haven't already begun the process.",                                                                 // EP117 eGemony, Part 1: Canadian Club
        "I believe in tough love. Also, tough tenderness, tough vulnerability, and a daily session of tough mindfulness meditation.",                       // EP125 A Door Ajar Part 2
        "Hey, what's your sign? Mine's a stop sign; I stole it from an intersection, and I hold it up every time someone tries to talk to me.",             // EP127 A Matter of Blood Part 1
        "Anything is a piñata if you hit it hard enough.",                                                                                                  // EP130 A Story About Us
        "Live every moment as if it were just one of the two and a half billion moments you have in your life. Seriously, pace yourself.",                  // EP132 Bedtime Story
        "True change starts with the person in the mirror. He’s standing far behind you, barely visible. He’s really going to change things.",              // EP133 Are You Sure? (Leann)
        "The universe contains, among other things, black holes, vast clouds of gas and light, a planet made of diamond, and your tiny body.",              // EP140 A Blood Stone Carol
        "A good way to tell if an artistic idea is worthwhile is to remember that the most successful video game of all time is \"a plumber steps on turtles.\" So, who knows.",    // EP141 Save Dark Owl Records
        "A group of chihuahuas is called a committee. A group of Labradors is called a jumble. A group of golden retrievers is called a butter dish.",      // EP146 The Birthday of Lee Marvin
        "\"Nothing lasts forever\" is a phrase with two meanings, and they're both true.",                                                                  // EP147 The Protester
        "Every friend group has a joyful chasm. If you do not know who the joyful chasm is, then I have news for you: you are the joyful chasm.",           // EP158 The Battle for Time
        "Correct placement from right to left: salad fork, soup spoon, salad spoon, bread knife, bowie knife, meat thermometer, entrée fork, and finally, the dessert claws.",      // EP161 The Space Race
        "Earth is technically a sandwich where the upper bread is stars, and the lower bread is stars, and the filling is rock and lava and a few incidental humans.",              // EP170 To the Family and Friends
        "The road to hell is paved with cobblestone. It's super bumpy. Not at all comfortable, and really bad for your car's suspension.",                  // EP176 The Autumn Specter
        "Don’t bite the hand that feeds you. Go for the legs. It’ll throw them off-balance.",                                                               // EP178 Rattlesnake Rest
    };
    private string text;
    // Start is called before the first frame update
    void Start()
    {
        System.Random rnd = new System.Random();
        text = Lore[rnd.Next(0, Lore.Length)];
    }

    public void Read()
    {
        GameObject.Find(GameObjectNames.Canvas).GetComponent<PauseGame>().Read();
        GameObject.Find(GameObjectNames.PaperText).GetComponent<Text>().text = text;
    }
}
