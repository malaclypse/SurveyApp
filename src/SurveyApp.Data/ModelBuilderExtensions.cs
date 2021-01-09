using Microsoft.EntityFrameworkCore;
using SurveyApp.Data.Models;
using System.Collections.Generic;
using System.IO;

public static class ModelBuilderExtensions
{
    public static void SeedTexts(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TextEntryEntity>().HasData(
            new TextEntryEntity
            {
                TextId = 1,
                Text = @"The girl was lying, half-dressed, upon it. He had roused her from her sleep, for she raised herself with a hurried and startled look. 
                         ‘Get up!’ said the man. 
                         ‘It is you, Bill!’ said the girl, with an expression of pleasure at his return. 
                         ‘It is,’ was the reply. ‘Get up.’ 
                         There was a candle burning, but the man hastily drew it from the candlestick, and hurled it under the grate. Seeing the faint light of early day without, the girl rose to undraw the curtain. 
                         ‘Let it be,’ said Sikes, thrusting his hand before her. ‘There’s enough light for wot I’ve got to do.’ 
                         ‘Bill,’ said the girl, in the low voice of alarm, ‘why do you look like that at me!’ 
                         The robber sat regarding her, for a few seconds, with dilated nostrils and heaving breast; and then, grasping her by the head and throat, dragged her into the middle of the room, and looking once towards the door, placed his heavy hand upon her mouth. 
                         ‘Bill, Bill!’ gasped the girl, wrestling with the strength of mortal fear,—‘I—I won’t scream or cry—not once—hear me—speak to me—tell me what I have done!’ 
                         ‘You know, you she devil!’ returned the robber, suppressing his breath. ‘You were watched to-night; every word you said was heard.’ 
                         ‘Then spare my life for the love of Heaven, as I spared yours,’ rejoined the girl, clinging to him. ‘Bill, dear Bill, you cannot have the heart to kill me. Oh! think of all I have given up, only this one night, for you. You SHALL have time to think, and save yourself this crime; I will not loose my hold, you cannot throw me off. Bill, Bill, for dear God’s sake, for your own, for mine, stop before you spill my blood! I have been true to you, upon my guilty soul I have!’ 
                         The man struggled violently, to release his arms; but those of the girl were clasped round his, and tear her as he would, he could not tear them away. 
                         ‘Bill,’ cried the girl, striving to lay her head upon his breast, ‘the gentleman and that dear lady, told me to-night of a home in some foreign country where I could end my days in solitude and peace. Let me see them again, and beg them, on my knees, to show the same mercy and goodness to you; and let us both leave this dreadful place, and far apart lead better lives, and forget how we have lived, except in prayers, and never see each other more. It is never too late to repent. They told me so—I feel it now—but we must have time—a little, little time!’ 
                         The housebreaker freed one arm, and grasped his pistol. The certainty of immediate detection if he fired, flashed across his mind even in the midst of his fury; and he beat it twice with all the force he could summon, upon the upturned face that almost touched his own. 
                         She staggered and fell: nearly blinded with the blood that rained down from a deep gash in her forehead; but raising herself, with difficulty, on her knees, drew from her bosom a white handkerchief—Rose Maylie’s own—and holding it up, in her folded hands, as high towards Heaven as her feeble strength would allow, breathed one prayer for mercy to her Maker. 
                         It was a ghastly figure to look upon. The murderer staggering backward to the wall, and shutting out the sight with his hand, seized a heavy club and struck her down."
            },
            new TextEntryEntity
            {
                TextId = 2,
                Text = @"“Shuden!” a voice said. “I see that you are lacking your customary circle of admirers.” 
                         “Good evening, Lord Roial,” Shuden said, bowing slightly as the old man approached. “Yes, thanks to my companionship, I have been able to avoid most of that tonight.” 
                         “Ah, the lovely Princess Sarene,” Roial said, kissing her hand. “Apparently, your penchant for black has waned.” 
                         “It was never that strong to begin with, my lord,” she said with a curtsy. 
                         “I can imagine,” Roial said with a smile. Then he turned back to Shuden. “I had hoped that you wouldn’t realize your good fortune, Shuden. I might have stolen the princess and kept off a few of the leeches myself.”
                         Sarene regarded the elderly man with surprise. 
                         Shuden chuckled. “Lord Roial is, perhaps, the only bachelor in Arelon whose affection is more sought-after than my own. Not that I am jealous. His Lordship diverts some of the attention from me.”
                          “You?” Sarene asked, looking at the spindly old man. “Women want to marry you?” Then, remembering her manners, she added a belated “my lord,” blushing furiously at the impropriety of her words. 
                         Roial laughed. “Don’t worry about offending me, young Sarene. No man my age is much to look at. My dear Eoldess has been dead for twenty years, and I have no son. My fortune has to pass to someone, and every unmarried girl in the realm realizes that fact. She would only have to indulge me for a few years, bury me, then find a lusty young lover to help spend my money.” 
                         “My lord is too cynical,” Shuden noted. 
                         “My lord is too realistic,” Roial said with a snort. “Though I’ll admit, the idea of forcing one of those young puffs into my bed is tempting. I know they all think I’m too old to make them perform their duties as a wife, but they assume wrong. If I were going to let them steal my fortune, I’d at least make them work for it.”
                          Shuden blushed at the comment, but Sarene only laughed. “I knew it. You really are nothing but a dirty old man.” 
                         “Self-professedly so,” Roial agreed with a smile."
            },
            new TextEntryEntity
            {
                TextId = 3,
                Text = @"“Why not ransom her to Nikolai Lantsov?” said a soldier from somewhere near the back of the circle. Now that I was in the middle of the clearing, there seemed to be even more of them. 
                         “Lantsov?” Luchenko said. “If he has a brain in his head, he’s rusticating somewhere warm with a pretty girl on his knee. If he’s even alive.” 
                         “He’s alive,” said someone.
                          Luchenko spat. “Makes no matter to me.” 
                         “And your country?” I asked. 
                         “What has my country ever done for me, little girl? No land, no life, just a uniform and a gun. Doesn’t matter if it’s the Darkling on the throne or some useless Lantsov.” 
                         “I saw the prince when I was in Os Alta,” said Ekaterina. “He’s not bad looking.” 
                         “Not bad looking?” said another voice. “He’s damnably handsome.” 
                         Luchenko scowled. “Since when—” 
                         “Brave in battle, smart as a whip.” 
                         Now the voice seemed to be coming from above us. Luchenko craned his neck, peering into the trees. 
                         “An excellent dancer,” said the voice. “Oh, and an even better shot.” 
                         “Who—” Luchenko never got to finish. A blast rang out, and a tiny black hole appeared between his eyes. 
                         I gasped. “Imposs—”
                          “Don’t say it,” muttered Mal. 
                         Then chaos erupted."
            },
            new TextEntryEntity
            {
                TextId = 4,
                Text = @"At that moment Gandalf lifted his staff, and crying aloud he smote the bridge before him. The staff broke asunder and fell from his hand. A blinding sheet of white flame sprang up. The bridge cracked. Right at the Balrog’s feet it broke, and the stone upon which it stood crashed into the gulf, while the rest remained, poised, quivering like a tongue of rock thrust out into emptiness. 
 
                         With a terrible cry the Balrog fell forward, and its shadow plunged down and vanished. But even as it fell it swung its whip, and the thongs lashed and curled about the wizard’s knees, dragging him to the brink. He staggered and fell, grasped vainly at the stone, and slid into the abyss. ‘Fly, you fools!’ he cried, and was gone. 
 
                         The fires went out, and blank darkness fell. The Company stood rooted with horror staring into the pit. Even as Aragorn and Boromir came flying back, the rest of the bridge cracked and fell. With a cry Aragorn roused them. 
 
                         ‘Come! I will lead you now!’ he called. ‘We must obey his last command. Follow me!’ 
 
                         They stumbled wildly up the great stairs beyond the door, Aragorn leading, Boromir at the rear. At the top was a wide echoing passage. Along this they fled. Frodo heard Sam at his side weeping, and then he found that he himself was weeping as he ran. Doom, doom, doom the drum-beats rolled behind, mournful now and slow; doom! 
 
                         They ran on. The light grew before them; great shafts pierced the roof. They ran swifter. They passed into a hall, bright with daylight from its high windows in the east. They fled across it. Through its huge broken doors they passed, and suddenly before them the Great Gates opened, an arch of blazing light. 
 
                         There was a guard of orcs crouching in the shadows behind the great door-posts towering on either side, but the gates were shattered and cast down. Aragorn smote to the ground the captain that stood in his path, and the rest fled in terror of his wrath. The Company swept past them and took no heed of them. Out of the Gates they ran and sprang down the huge and age-worn steps, the threshold of Moria. 
 
                         Thus, at last, they came beyond hope under the sky and felt the wind on their faces. 
                         They did not halt until they were out of bowshot from the walls. Dimrill Dale lay about them. The shadow of the Misty Mountains lay upon it, but eastwards there was a golden light on the land. It was but one hour after noon. The sun was shining; the clouds were white and high. 
 
                         They looked back. Dark yawned the archway of the Gates under the mountain-shadow. Faint and far beneath the earth rolled the slow drum-beats: doom. A thin black smoke trailed out. Nothing else was to be seen; the dale all around was empty. Doom. Grief at last wholly overcame them, and they wept long: some standing and silent, some cast upon the ground. Doom, doom. The drum-beats faded."
            },
            new TextEntryEntity
            {
                TextId = 5,
                Text = @"The room in which the boys were fed, was a large stone hall, with a copper at one end: out of which the master, dressed in an apron for the purpose, and assisted by one or two women, ladled the gruel at mealtimes. Of this festive composition each boy had one porringer, and no more—except on occasions of great public rejoicing, when he had two ounces and a quarter of bread besides. 
                         The bowls never wanted washing. The boys polished them with their spoons till they shone again; and when they had performed this operation (which never took very long, the spoons being nearly as large as the bowls), they would sit staring at the copper, with such eager eyes, as if they could have devoured the very bricks of which it was composed; employing themselves, meanwhile, in sucking their fingers most assiduously, with the view of catching up any stray splashes of gruel that might have been cast thereon. Boys have generally excellent appetites. Oliver Twist and his companions suffered the tortures of slow starvation for three months: at last they got so voracious and wild with hunger, that one boy, who was tall for his age, and hadn’t been used to that sort of thing (for his father had kept a small cook-shop), hinted darkly to his companions, that unless he had another basin of gruel per diem, he was afraid he might some night happen to eat the boy who slept next him, who happened to be a weakly youth of tender age. He had a wild, hungry eye; and they implicitly believed him. A council was held; lots were cast who should walk up to the master after supper that evening, and ask for more; and it fell to Oliver Twist. 
                         The evening arrived; the boys took their places. The master, in his cook’s uniform, stationed himself at the copper; his pauper assistants ranged themselves behind him; the gruel was served out; and a long grace was said over the short commons. The gruel disappeared; the boys whispered each other, and winked at Oliver; while his next neighbours nudged him. Child as he was, he was desperate with hunger, and reckless with misery. He rose from the table; and advancing to the master, basin and spoon in hand, said: somewhat alarmed at his own temerity: 
                         ‘Please, sir, I want some more.’ 
                         The master was a fat, healthy man; but he turned very pale. He gazed in stupified astonishment on the small rebel for some seconds, and then clung for support to the copper. The assistants were paralysed with wonder; the boys with fear. 
                         ‘What!’ said the master at length, in a faint voice. 
                         ‘Please, sir,’ replied Oliver, ‘I want some more.’ 
                         The master aimed a blow at Oliver’s head with the ladle; pinioned him in his arm; and shrieked aloud for the beadle. 
                         The board were sitting in solemn conclave, when Mr. Bumble rushed into the room in great excitement, and addressing the gentleman in the high chair, said, ‘Mr. Limbkins, I beg your pardon, sir! Oliver Twist has asked for more!’ 
                         There was a general start. Horror was depicted on every countenance. 
                         ‘For MORE!’ said Mr. Limbkins. ‘Compose yourself, Bumble, and answer me distinctly. Do I understand that he asked for more, after he had eaten the supper allotted by the dietary?’ 
                         ‘He did, sir,’ replied Bumble. ‘That boy will be hung,’ said the gentleman in the white waistcoat. ‘I know that boy will be hung.’"
            },
            new TextEntryEntity
            {
                TextId = 6,
                Text = @"One of the early entries in The Nice and Accurate Prophecies concerned Agnes Nutter's own death.            
                         The English, by and large, being a crass and indolent race, were not as keen on burning women as other countries in Europe. In Germany the bonfires were built and burned with regular Teutonic thoroughness. Even the pious Scots, locked throughout history in a long-drawn-out battle with their arch-enemies the Scots, managed a few burnings to while away the long winter evenings. But the English never seemed to have the heart for it.            
                         One reason for this may have to do with the manner of Agnes Nutter's death, which more or less marked the end of the serious witchhunting craze in England. A howling mob, reduced to utter fury by her habit of going around being intelligent and curing people, arrived at her house one April evening to find her sitting with her coat on, waiting for them.            
                         ""Ye're tardie,"" she said to them. ""I shoulde have beene aflame ten minutes since.""            
                         Then she got up and hobbled slowly through the suddenly silent crowd, out of the cottage, and to the bonfire that had been hastily thrown together on the village green. Legend says that she climbed awkwardly onto the pyre and thrust her arms around the stake behind her.           
                          ""Tye yt well,"" she said to the astonished witchfinder. And then, as the villagers sidled toward the pyre, she raised her handsome head in the firelight and said, ""Gather ye ryte close, goode people. Come close untyl the fire near scorch ye, for I charge ye that alle must see how thee last true wytch in England dies. For wytch I am, for soe I am judgéd, yette I knoe not what my true Cryme may be. And therefore let myne deathe be a messuage to the worlde. Gather ye ryte close, I saye, and marke well the fate of alle who meddle with suche as theye do none understande.""            
                         And, apparently, she smiled and looked up at the sky over the village and added, ""That goes for you as welle, yowe daft old foole.""            
                         And after that strange blasphemy she said no more. She let them gag her, and stood imperiously as the torches were put to the dry wood.            
                         The crowd grew nearer, one or two of its members a little uncertain as to whether they'd done the right thing, now they came to think about it.            
                         Thirty seconds later an explosion took out the village green, scythed the valley clean of every living thing, and was seen as far away as Halifax.            
                         There was much subsequent debate as to whether this had been sent by God or by Satan, but a note later found in Agnes Nutter's cottage indicated that any divine or devilish intervention had been materially helped by the contents of Agnes's petticoats, wherein she had with some foresight concealed eighty pounds of gunpowder and forty pounds of roofing nails.
                                     What Agnes also left behind, on the kitchen table beside a note cancelling the milk, was a box and a book. There were specific instructions as to what should be done with the box, and equally specific instructions about what should be done with the book; it was to be sent to Agnes's son, John Device.            
                         The people who found it—who were from the next village, and had been woken up by the explosion—considered ignoring the instructions and just burning the cottage, and then looked around at the twinkling fires and nail-studded wreckage and decided not to. Besides, Agnes's note included painfully precise predictions about what would happen to people who did not carry out her orders.            
                         The man who put the torch to Agnes Nutter was a Witchfinder Major. They found his hat in a tree two miles away.            
                         His name, stitched inside on a fairly large piece of tape, was ThouShalt-Not-Commit-Adultery Pulsifer, one of England's most assiduous witchfinders, and it might have afforded him some satisfaction to know that his last surviving descendant was now, even if unawares, heading toward Agnes Nutter's last surviving descendant. He might have felt that some ancient revenge was at last going to be discharged.           
                         If he'd known what was actually going to happen when that descendant met her he would have turned in his grave, except that he had never got one."
            },
            new TextEntryEntity
            {
                TextId = 7,
                Text = @"Sarene stepped off of the ship to discover that she was a widow. It was shocking news, of course, but not as devastating as it could have been. After all, she had never met her husband. In fact, when Sarene had left her homeland, she and Raoden had only been engaged. She had assumed that the kingdom of Arelon would wait to hold the wedding until she actually arrived. Where she came from, at least, it was expected that both partners would be present when they were married. 
                         “I never liked that clause in the wedding contract, my lady,” said Sarene’s companion—a melon-sized ball of light hovering at her side. Sarene tapped her foot in annoyance as she watched the packmen load her luggage onto a carriage. The wedding contract had been a fifty-page beast of a document, and one of its many stipulations made her betrothal legally binding if either she or her fiancé died before the actual wedding ceremony. 
                         “It’s a fairly common clause, Ashe,” she said. “That way, the treaty of a political marriage isn’t voided if something happens to one of the participants. I’ve never seen it invoked.”
                          “Until today,” the ball of light replied, its voice deep and its words well enunciated.
                          “Until today,” Sarene admitted. “How was I to know Prince Raoden wouldn’t last the five days it took us to cross the Sea of Fjorden?” She paused, frowning in thought. “Quote the clause to me, Ashe. I need to know exactly what it says.”
                         “‘If it happens that one member of the aforementioned couple is called home to Merciful Domi before the prearranged wedding time,’” Ashe said, “‘then the engagement will be considered equivalent to marriage in all legal and social respects.’” 
                         “Not much room for argument, is there?” 
                         “Afraid not, my lady.” Sarene frowned distractedly, folding her arms and tapping her cheek with her index finger, watching the packmen. A tall, gaunt man directed the work with bored eyes and a resigned expression. The man, an Arelish court attendant named Ketol, was the only reception King Iadon had seen fit to send her. Ketol had been the one to “regretfully inform her” that her fiancé had “died of an unexpected disease” during her journey. He had made the declaration with the same dull, uninterested tone that he used to command the packmen.
                          “So,” Sarene clarified, “as far as the law is concerned, I’m now a princess of Arelon.” 
                         “That is correct, my lady.” 
                         “And the widowed bride of a man I never met.” “Again, correct.” Sarene shook her head. “Father is going to laugh himself sick when he hears about this. I’ll never live it down.”"
            },
            new TextEntryEntity
            {
                TextId = 8,
                Text = @"The memory was fresh, only a few days old: Door moved through the House Without Doors calling “I’m home,” and “Hello?” She slipped from the anteroom to the dining room, to the library, to the drawing room; no one answered. She moved to another room.
 
                         The swimming pool was an indoor Victorian structure, constructed of marble and of cast iron. Her father had found it when he was younger, abandoned and about to be demolished, and he had woven it into the fabric of the House Without Doors. Perhaps in the world outside, in London Above, the room had long been destroyed and forgotten. Door had no idea where any of the rooms of her house were, physically. Her grandfather had constructed the house, taking a room from here, a room from there, all through London, discrete and doorless; her father had added to it.
 
                         She walked along the side of the old swimming pool, pleased to be home, puzzled by the absence of her family. And then she looked down.
 
                         There was someone floating in the water, trailing twin clouds of blood behind him, one from the throat, one from the groin. It was her brother, Arch. His eyes were open wide and sightless. She realized that her mouth was open. She could hear herself screaming.
 
                         They were in the conservatory, watering the plants. First Portia would water a plant, directing the flow of the water toward the soil at the base of the plant, avoiding the leaves and the blossoms. “Water the shoes,” she said to her youngest daughter. “Not the clothes.”
 
                         Ingress had her own little watering can. She was so proud of it. It was just like her mother’s, made of steel, painted bright green. As her mother finished with each plant, Ingress would water it with her tiny watering can. “On the shoes,” she told her mother. She began laughing, then, spontaneous little-girl laughter.
 
                         And her mother laughed too, until foxy Mr. Croup pulled her hair back, hard and sudden, and cut her white throat from ear to ear."
            },
            new TextEntryEntity
            {
                TextId = 9,
                Text = @"“Little Sarene, all grown up now,” her father said through the Seon link. 
                         “All grown up and fully capable of marrying herself off to a corpse.” Sarene laughed weakly. “It’s probably for the best. I don’t think Prince Raoden would have turned out as I had imagined—you should meet his father.”
                          “I’ve heard stories. I hoped they weren’t true.”
                          “Oh, they are,” Sarene said, letting her dissatisfaction with the Arelish monarch burn away her sorrow. “King Iadon has to be just about the most disagreeable man I have ever met. He barely even acknowledged me before sending me off to, as he put it, ‘go knit, and whatever else you women do.’ If Raoden was anything like his father, then I’m better off this way.” 
                         There was a momentary pause before her father responded. 
                         “Sarene, do you want to come home? I can void the contract if I want, no matter what the laws say.” 
                         The offer was tempting—more tempting than she would ever admit. She paused. “No, Father,” she finally said with an unconscious shake of her head. “I have to stay. This was my idea, and Raoden’s death doesn’t change the fact that we need this alliance. Besides, returning home would break tradition—we both know that Iadon is my father now. It would be unseemly for you to take me back into your household.”
                          “I will always be your father, ’Ene. Domi curse the customs—Teod will always be open for you.”
                          “Thank you, Father,” Sarene said quietly. “I needed to hear that. But I still think I should stay. For now, at least. Besides, it could be interesting. I have an entirely new court full of people to play with.”
                          “’Ene …” her father said apprehensively. “I know that tone. What are you planning?” 
                         “Nothing,” she said. “There’s just a few things I want to poke my nose into before I give up completely on this marriage.”
                          There was a pause, and then her father chuckled.
                          “Domi protect them—they don’t know what we’ve shipped over there. Go easy on them, Leky Stick. I don’t want to get a note from Minister Naolen in a month telling me that King Iadon has run off to join a Korathi monastery and the Arelish people have named you monarch instead.”
                         “All right,” Sarene said with a wan smile. “I’ll wait at least two months then.” Her father burst into another round of his characteristic laughter— a sound that did her more good than any of his consolations or counsels.
                          “Wait for a minute, ’Ene,” he said after his laughter subsided. “Let me get your mother—she’ll want to speak with you.” Then, after a moment, he chuckled, continuing, “She’s going to faint dead away when I tell her you’ve already killed off poor Raoden.” 
                         “Father!” Sarene said—but he was already gone."
            },
            new TextEntryEntity
            {
                TextId = 10,
                Text = @"Stephanie hung up and grinned. 
                         She sat on the couch and was just getting comfy when the house phone rang. She looked at it, resting there on the table at her elbow. Who would be calling? Anyone who knew Gordon had died wouldn’t be calling, because they’d know he had died, and she didn’t really want to be the one to tell anyone who didn’t know. It could be her parents—but then why didn’t they just call her mobile? Figuring that as the new owner of the house it was her responsibility to answer her own phone, Stephanie picked it up.
                         “Hello?” Silence. “Hello?” Stephanie repeated. 
                         “Who is this?” came a man’s voice. 
                         “I’m sorry,” Stephanie said, “who are you looking for?” 
                         “Who is this?” responded the voice, more irritably this time. 
                         “If you’re looking for Gordon Edgley,” Stephanie said, “I’m afraid that he’s—” 
                         “I know Edgley’s dead,” snapped the man. “Who are you? Your name?”
                         Stephanie hesitated. “Why do you want to know?” she asked. 
                         “What are you doing in that house? Why are you in his house?” 
                         “If you want to call back tomorrow—” 
                         “I don’t want to, all right? Listen to me, girlie: If you mess up my master’s plans, he will be very displeased, and he is not a man you want to displease—you got that? Now tell me who you are!” 
                         Stephanie realized her hands were shaking. She forced herself to calm down, and quickly found anger replacing her nervousness. “My name is none of your business,” she said. “If you want to talk to someone, call back tomorrow at a reasonable hour.” 
                         “You don’t talk to me like that,” the man hissed. 
                         “Good night,” Stephanie said firmly.
                         “You do not talk to me like—” But Stephanie was already putting the phone down. 
                         Suddenly the idea of spending the whole night here wasn’t as appealing as it had first seemed. She considered calling her parents, then scolded herself for being so childish. No need to worry them, she thought; no need to worry them about something so— Someone pounded on the front door. 
                         “Open up!” came the man’s voice between the pounding. Stephanie got to her feet, staring through to the hall beyond the living room. She could see a dark shape behind the frosted glass around the front door. “Open the damn door!” 
                         Stephanie backed up to the fireplace, her heart pounding in her chest. He knew she was in here—there was no use pretending that she wasn’t—but maybe if she stayed really quiet, he’d give up and go away. She heard him cursing, and the pounding grew so heavy that the front door rattled under the blows. 
                         “Leave me alone!” Stephanie shouted.
                          “Open the door!” 
                         “No!” she shouted back. She liked shouting; it disguised her fear. “I’m calling the police! I’m calling the police right now!”
                         The pounding stopped immediately, and she saw the shape move away from the door. Was that it? Had she scared him away? She thought of the back door—was it locked? Of course it was locked—it had to be locked. But she wasn’t sure, she wasn’t certain. She grabbed a poker from the fireplace and was reaching for the phone when she heard a knock on the window beside her. She cried out and jumped back. The curtains were open, and outside the window was pitch-black. She couldn’t see a thing. 
                         “Are you alone in there?” came the voice. It was teasing now, playing with her. 
                         “Go away,” she said loudly, holding up the poker so that he could see it. She heard the man laugh. 
                         “What are you going to do with that?” he asked from outside. 
                         “I’ll break your head open with it!” Stephanie screamed at him, fear and fury bubbling inside her. She heard him laugh again. 
                         “I just want to come in,” he said. “Open the door for me, girlie. Let me come in.” 
                         “The police are on their way,” she said. 
                         “You’re a liar.” Still she could see nothing beyond the glass, and he could see everything. 
                         She snatched the phone from its cradle. 
                         “Don’t do that,” came the voice. 
                         “I’m calling the police.” 
                         “The road’s closed, girlie. You call them, I’ll break down that door and kill you hours before they get here.” 
                         Fear became terror and Stephanie froze. She was going to cry. She could feel the tears welling up inside her. She hadn’t cried in years. “What do you want?” she said to the darkness. “Why do you want to come in?” 
                         “It’s got nothing to do with me, girlie. I’ve just been sent to pick something up. Let me in; I’ll look around, get what I came here for, and leave. I won’t harm a pretty little hair on your pretty little head, I promise. Now you just open that door right this second.”
                         Stephanie gripped the poker in both hands and shook her head. She was crying now, tears rolling down her cheeks.“No,” she said. 
                         She screamed as a fist smashed through the window, showering the carpet with glass. She stumbled back as the man started climbing in, glaring at her with blazing eyes, unmindful of the glass that cut into him. The moment his foot touched the floor inside the house, Stephanie bolted out of the room and over to the front door, fumbling at the lock. 
                         Strong hands grabbed her from behind. She screamed again as she was lifted off her feet and carried back. She kicked out, slamming a heel into his shin. The man grunted and let go. Stephanie twisted, trying to swing the poker into his face, but he caught it and pulled it from her grasp. One hand went to her throat, and Stephanie gagged, unable to breathe as the man forced her back into the living room. He pushed her into an armchair and leaned in on her. No matter how hard she tried, she could not break his grip.
                         “Now then,” the man said, his mouth contorting into a sneer, “why don’t you just give me the key, little girlie?”"
                                    },
            new TextEntryEntity
            {
                TextId = 11,
                Text = @"Crowley's London flat was the epitome of style. It was everything that a flat should be: spacious, white, elegantly furnished, and with that designer unlived-in look that only comes from not being lived in.           
                         This is because Crowley did not live there.           
                          It was simply the place he went back to, at the end of the day, when he was in London. The beds were always made; the fridge was always stocked with gourmet food that never went off (that was why Crowley had a fridge, after all), and for that matter the fridge never needed to be defrosted, or even plugged in.            
                         The lounge contained a huge television, a white leather sofa, a video and a laserdisc player, an ansaphone, two telephones—the ansaphone line, and the private line (a number so far undiscovered by the legions of telephone salesmen who persisted in trying to sell Crowley double glazing, which he already had, or life insurance, which he didn't need)—and a square matte black sound system, the kind so exquisitely engineered that it just has the onoff switch and the volume control. The only sound equipment Crowley had overlooked was speakers; he'd forgotten about them. Not that it made any difference. The sound reproduction was quite perfect anyway.            
                         There was an unconnected fax machine with the intelligence of a computer and a computer with the intelligence of a retarded ant. Nevertheless, Crowley upgraded it every few months, because a sleek computer was the sort of thing Crowley felt that the sort of human he tried to be would have. This one was like a Porsche with a screen. The manuals were still in their transparent wrapping.            
                         In fact the only things in the flat Crowley devoted any personal attention to were the houseplants. They were huge and green and glorious, with shiny, healthy, lustrous leaves.            This was because, once a week, Crowley went around the flat with a green plastic plant mister, spraying the leaves, and talking to the plants.           
                          He had heard about talking to plants in the early seventies, on Radio Four, and thought it an excellent idea. Although talking is perhaps the wrong word for what Crowley did.           
                         What he did was put the fear of God into them. 
                         More precisely, the fear of Crowley.           
                          In addition to which, every couple of months Crowley would pick out a plant that was growing too slowly, or succumbing to leaf-wilt or browning, or just didn't look quite as good as the others, and he would carry it around to all the other plants. ""Say goodbye to your friend,"" he'd say to them. ""He just couldn't cut it…""           
                          Then he would leave the flat with the offending plant, and return an hour or so later with a large, empty flower pot, which he would leave somewhere conspicuously around the flat.            
                         The plants were the most luxurious, verdant, and beautiful in London. Also the most terrified."
            },
            new TextEntryEntity
            {
                TextId = 12,
                Text = @"The damp, muddy Richard stared into the face of the clean, well-dressed Richard, and he said, “I don’t know who you are or what you’re trying to do. But you aren’t even very convincing: you don’t really look like me.” He was lying, and he knew it.
                         His other self smiled encouragingly, and shook his head. “I’m you, Richard,” he said. “I’m whatever’s left of your sanity . . .”
                         It was not the embarassing echo of his voice he heard on answering machines, on tapes and home videos, that horrid parody of a voice that passed for his: the man spoke with Richard’s true voice, the voice he heard in his head when he spoke, resonant and real.
                         “Concentrate!” shouted the man with Richard’s face. “Look at this place, try to see the people, try to see the truth . . . you’re already the closest to reality that you’ve been in a week...”
                         “This is bullshit,” said Richard, flatly, desperately. He shook his head, denying everything his other self was saying, but, still, he looked at the platform, wondering what it was he was meant to be seeing. Then something flickered, at the corner of his vision; he followed it with his head, but it was gone.
                         “Look,” whispered his double. “See.”
                         “See what?” He was standing on an empty, dimly lit station platform, a lonely mausoleum of a place. And then . . .
                         The noise and the light struck him like a bottle across the face: he was standing on Blackfriars Station, in the middle of the rush hour. People bustled by him: a riot of noise and light, of shoving, moving humanity. There was an Underground train waiting at the platform, and, reflected in its window, Richard could see himself. He looked crazy; he had a week’s growth of beard; food was crusted around his mouth; one eye had recently been blackened, and a boil, an angry red carbuncle, was coming up on the side of his nose; he was filthy, covered in a black, encrusted dirt which filled his pores and lived under his fingernails; his eyes were red and bleary, his hair was matted and snarled. He was a crazy homeless person, standing on a platform of a busy Underground station, in the heart of the rush hour.
                         Richard buried his face deep in his hands.
                         When he raised his face, the other people were gone. The platform was dark again, and he was alone. He sat down on a bench and closed his eyes. A hand found his hand, held it for some moments, and then squeezed it. A woman’s hand: he could smell a familiar perfume.
                         The other Richard sat on his left, and now Jessica sat on his right, holding his hand in hers, looking at him compassionately. He had never seen that expression on her face before.
                         “Jess?” he said.
                         Jessica shook her head. She let go of his hand. “I’m afraid not,” she said. “I’m still you. But you have to listen, darling. You’re the closest to reality you’ve been—”
                         “You people keep saying, the closest to reality, the closest to sanity, I don’t know what you . . .” He paused. Something came back to him, then. He looked at the other version of himself, at the woman he had loved. 
                         “Listen to yourself,” said the other Richard, gently. “Can’t you tell how ridiculous all this sounds?”
                         Jessica looked as if she were trying not to cry. Her eyes glistened. “You’re not going through an ordeal, Richard. You—you had some kind of nervous breakdown. A couple of weeks ago. I think you just cracked up. I broke off our engagement—you’d been acting so strangely, it was like you were a different person, I—I couldn’t cope. . . .Then you vanished . . .” The tears began to run down her cheeks, and she stopped talking to blow her nose on a tissue.
                         The other Richard began to speak. “I wandered, alone and crazy, through the streets of London, sleeping under bridges, eating food from garbage cans. Shivering and lost and alone. Muttering to myself, talking to people who weren’t there . . .”
                         “I’m so sorry, Richard,” said Jessica. She was crying, now, her face contorted and unattractive. Her mascara was beginning to run, and her nose was red. He had never seen her hurting before, and he realized how much he wanted to take her pain away. Richard reached out for her, to try to hold her, to comfort and reassure her, but the world slid and twisted and changed . . .
                         Someone stumbled into him, cursed and walked away. Richard was lying prone on the platform, in the rush-hour glare. The side of his face was sticky and cold. He pulled his head up off the ground. He had been lying in a pool of his own vomit. At least, he hoped it was his own. Passersby stared at him with revulsion, or, after one flick of the eyes, did not look at him again.
                         He wiped at his face with his hands and tried to get up, but he could no
                         longer remember how. Richard began to whimper. He shut his eyes tightly, and he kept them shut. When he opened them, thirty seconds, or an hour, or a day later, the platform was in semidarkness. He climbed to his feet. There was nobody there. “Hello?” he called. “Help me. Please.”"
            },
            new TextEntryEntity
            {
                TextId = 13,
                Text = @"Suddenly Burrich's face peered in my window. For a moment we stood eye to eye at the barred window. Grief and outrage battled in his face. His eyes were webbed red from his drinking, and his breath was strong with it. The fabric of his shirt showed ragged where the buck crest had been torn from it. He glared at me, then, as he looked at me, his eyes widened in shock. For a moment our gaze held, and I thought something of understanding and farewell passed between us. Then he leaned back and spat full in my face.
 
                         ""That, for you,"" he snarled. ""That for my life, which you took from me. All the hours, all the days I spent upon you.
 
                         Better that you had lain down and died amongst the beasts before you let this come to pass. They're going to hang you; boy. Regal's having the gallows built, over water, like the old wisdom says. They'll hang you, then cut you up and burn you down to bones. Nothing left to bury. He's probably afraid the dogs would dig you up again. You'd like that, hey, boy? Buried like a bone, for some dog to dig up later? Better to just lie down and die right where you are.""
 
                         I had recoiled from him when he spat at me. Now I stood back from my door, swaying on my feet while he gripped the bars and stared in at me, his eyes wide and bright with madness and drink.
 
                         ""You're so good with the Wit, they say. Why don't you change into a rat and scuttle out of there? Huh?"" He leaned his forehead against the bars and peered in at me. Almost pensively, he said, ""Better that than to hang, whelp. Change into a beast and run off with your tail between your legs. If you can ... I heard you can ... they say you can turn into a wolf. Well, unless you can, you're going to hang. Hang by your neck, choking and kicking ..."" His voice trailed off. His dark eyes locked with mine. They were teary with drink. ""Better to lie down and die right there than hang."" Suddenly he seemed full of fury. ""Maybe I'll help you lie down and die!"" he threatened through gritted teeth. ""Better you die my way than Regal's! "" He began to wrest at the bars, shaking the door back and forth against its locks.
 
                         The guards were instantly on him, one to an arm, tugging and cursing while he ignored them. Old Blade jigged up and down behind them, saying, ""Give it up, come on, Burrich, you had your say, come on, man, before there's real trouble.""
 
                         They did not pry him loose, but he gave it up suddenly, just dropping his arms to his sides. It caught the guards by surprise and they both stumbled back. I clutched at the barred window.
                         ""Burrich."" It was hard to make my mouth form words. ""I never meant to hurt you. I'm sorry."" I took a breath, tried to find some words to end some of the torment in his eyes. ""No one should blame you. You did the best with me you could.""
 
                         He shook his head at me, his face con"
            },
            new TextEntryEntity
            {
                TextId = 14,
                Text = @"Kaz’s eyes narrowed. “Sturmhond.” 
                         “He knows me!” Sturmhond said delightedly. He nudged Genya with an elbow. “I told you I’m famous.” 
                         Zoya blew out an exasperated breath. “Thank you. He’s going to be twice as insufferable now.” 
                         “Sturmhond has been authorized to negotiate on behalf of the Ravkan throne,” said Genya.
                          “A pirate?” asked Jesper. 
                         “Privateer,” Sturmhond corrected. “You can’t expect the king to participate in an auction like this himself.”
                          “Why not?” 
                         “Because he might lose. And it looks very bad when kings lose.” Jesper couldn’t quite believe he was having a conversation with the Sturmhond. The privateer was a legend. He’d broken countless blockades on behalf of the Ravkans, and there were rumors that … 
                         “Do you really have a flying ship?” blurted Jesper. 
                         “No.” 
                         “Oh.”
                          “I have several.” 
                         “Take me with you.”
                          Kaz didn’t look remotely entertained. “The Ravkan king lets you negotiate for him in matters of state?” he asked skeptically. 
                         “Occasionally,” said Sturmhond. “Especially if less than savory personages are involved. You have a reputation, Mister Brekker.” 
                         “So do you.” 
                         “Fair enough. So let’s say we’ve both earned the right to have our names bandied about in the worst circles. The king won’t drag Ravka into one of your schemes blindly. Nina’s note claimed that you have Kuwei Yul-Bo in your possession. I want confirmation of that fact, and I want the details of your plan.” 
                         “All right,” said Kaz. “Let’s talk in the solarium. I’d prefer not to sweat through my suit.” 
                         When the rest of them made to follow, Kaz halted and glanced over his shoulder. “Just me and the privateer.” 
                         Zoya tossed her glorious black mane and said, “We are the Triumvirate. We do not take orders from Kerch street rats with dubious haircuts.” 
                         “I can phrase it as a question if it will make your feathers lie flat,” Kaz said."
            },
            new TextEntryEntity
            {
                TextId = 15,
                Text = @"Over the years a huge number of theological man-hours have been spent debating the famous question: How Many Angels Can Dance on the Head of a Pin?            
                         In order to arrive at an answer, the following facts must be taken into consideration:            Firstly, angels simply don't dance. It's one of the distinguishing characteristics that marks an angel. They may listen appreciatively to the Music of the Spheres, but they don't feel the urge to get down and boogie to it. So, none.            
                         At least, nearly none. Aziraphale had learned to gavotte in a discreet gentlemen's club in Portland Place, in the late 1880s, and while he had initially taken to it like a duck to merchant banking, after a while he had become quite good at it, and was quite put out when, some decades later, the gavotte went out of style for good.           
                          So providing the dance was a gavotte, and providing that he had a suitable partner (also able, for the sake of argument, both to gavotte, and to dance it on the head of a pin), the answer is a straightforward one.           
                          Then again, you might just as well ask how many demons can dance on the head of a pin. They're of the same original stock, after all. And at least they dance.        
                         And if you put it that way, the answer is, quite a lot actually, providing they abandon their physical bodies, which is a picnic for a demon. Demons aren't bound by physics. If you take the long view, the universe is just something small and round, like those water-filled balls which produce a miniature snowstorm when you shake them.* But if you look from really
                         close up, the only problem about dancing on the head of a pin is all those big gaps between electrons.           
                         For those of angel stock or demon breed, size, and shape, and composition, are simply options.            
                         Crowley is currently traveling incredibly fast down a telephone            
                         RING.            
                         Crowley went through two telephone exchanges at a very respectable fraction of light-speed. Hastur was a little way behind him: four or five inches, but at that size it gave Crowley a very comfortable lead. One that would vanish, of course, when he came out the other end.           
                          They were too small for sound, but demons don't necessarily need sound to communicate. He could hear Hastur screaming behind him, ""You bastard! I'll get you. You can't escape me!""           
                          RING.           
                          ""Wherever you come out, I'll come out too! You won't get away!""          
                           Crowley had traveled through over twenty miles of cable in less than a second.            Hastur was close behind him. Crowley was going to have to time this whole thing very, very carefully.            
                         RING.           
                         That was the third ring. Well, thought Crowley, here goes nothing. He stopped, suddenly, and watched Hastur shoot past him. Hastur turned and—          
                          RING.          
                          Crowley shot out through the phone line, zapped through the plastic sheathing, and materialized, full-size and out of breath, in his lounge. click."
            },
            new TextEntryEntity
            {
                TextId = 16,
                Text = @"I am warm and safe in the den, with my two siblings. They are both heartier and stronger than I am. Born last, I am smallest of all. My eyes were slow to open, and I have been the least adventurous of the cubs. Both my brother and my sister have dared, more than once, to follow my mother to the mouth of the den dug deep in the undercut bank of the river. Each time, she has snarled and snapped at them, driving them back. She leaves us alone when she goes out to hunt. There should be a wolf to watch over us, a younger member of the pack who remains with us. But my mother is all that is left of the pack, and so she must go out to hunt alone and we must stay where she leaves us. 
 
                         There is a day when she shakes free of us, long before we have had enough of her milk. She leaves us, going to the hunt, departing the den as evening starts to creep across the land. We hear from her a single yelp. That is all. 
 
                         My brother, the largest of us, is filled with both fear and curiosity. He whines loudly, trying to call her back to us, but there is no response. He starts to go to the entrance of the den and my sister follows him, but in a moment they come scrabbling back to hunker down in fear beside me. There are strange smells right outside the den, bad smells, blood and creatures unknown to us. As we hide and whimper, the blood-smell grows stronger. We do the only thing we know to do. We hunch and huddle against the far back wall. 
 
                         We hear sounds. Something that is not paws digs at the mouth of our den. It sounds like a large tooth biting into the earth, biting and tearing, biting and tearing. We hunch even deeper and my brother’s hackles rise. We hear sounds and we know there is more than one creature outside. The blood-smell thickens and is mingled with the smell of our mother. The digging noises go on. 
 
                         Then there is another smell. In years to come I will know what it is, but in the dream it is not smoke. It is a smell that none of us understands, and it comes in driven wafts into the den. We cry, for it stings our eyes and sucks the breath from our lungs. The den becomes hot and airless and finally my brother crawls toward the opening. We hear his wild yelping, and how it continues, and then there is the stink of fear-piss. My sister huddles behind me, getting smaller and stiller. And then she is not breathing or hiding anymore. She is dead. 
 
                         I sink down, my paws over my nose, my eyes blinded by the smoke. The digging noises go on and then something seizes me. I yelp and struggle, but it holds tight to my front leg and drags me from the den. 
 
                         My mother is a hide and a bloody red carcass thrown to one side. My brother huddles in terror at the bottom of a cage in the back of a two-wheeled cart. They fling me in beside him and then drag out my sister’s body. They are angry she is dead, and they kick her as if somehow their anger can make her feel pain now. Then, complaining of the cold and oncoming dark, they skin her and add her small hide to my mother’s. The two men climb onto the cart and whip up their mule, already speculating at the prices that wolf cubs will bring from the dog-fighting markets. My mother’s and sister’s bloody hides fill my nose with the stench of death. 
 
                         It is only the beginning of a torment that lasts for a lifetime. Some days we are fed and sometimes not. We are given no shelter from the rain. The only warmth is that of our own bodies as we huddle together. My brother, thin with worms, dies in a pit, thrown in to whet the ferocity of the fighting dogs. And then I am alone. They feed me offal and scraps or nothing at all. My feet become sore from pawing at the cage, my claws split and my muscles ache from confinement. They beat me and poke me to provoke me to hurl myself against bars I cannot break. They speak outside my cage of their plans to sell me for the fighting pits. I hear the words but I do not understand them."
            },
            new TextEntryEntity
            {
                TextId = 17,
                Text = @"Kuwei    was coughing    water,    and Matthias was dragging a limp, unconscious Kaz out of    the shallows. 
                         “Saints, is he breathing?” asked Nina. 
                         Matthias flipped him onto his    back none too    gently and started pressing down on    his    chest with more force than was strictly necessary. “I. Should. Let. You. Die,” Matthias muttered in time    with his compressions. 
                         Nina crawled over the    rocks and kneeled beside them, “Let    me help before you crack his sternum. Does he have a pulse?” She pressed her fingers    to his throat. 
                         “It’s there, but    it’s fading. Get    his shirt open.” Matthias helped tear    the uniform away. Nina placed one hand on Kaz’s pale    chest, focusing on his    heart and forcing it to    contract.    She used the other to pinch his nose shut and push his mouth open as she tried to breathe air into his lungs. More skilled Corporalki could extract the water themselves, but she didn’t    have time to fret over her lack of training. 
                         “Will he live?” Kuwei asked. 
                         I don’t know. She pressed her lips to Kaz’s again, timing her breaths with the beats she demanded of his heart. Come on, you rotten     Barrel    thug. You’ve fought your way out of tougher scrapes. She felt the    shift when Kaz’s heart took over its own rhythm. 
                         Then he coughed, chest spasming, water spewing from his mouth. He shoved her off of him, sucking in air. “Get away from me,” he gasped, wiping his gloved hand over his mouth. Kaz’s eyes were unfocused. He seemed to be staring right through her. “Don’t touch me.” 
                         “You’re    in shock, idiot,” Matthias said. “You almost drowned. You should have drowned.” 
                         Kaz coughed again, and his entire body shuddered. “Drowned,” he repeated. 
                         Nina nodded slowly.“Ice Court, remember? Impossible    heist?    Near    death?    Three    million    kruge waiting    for you in Ketterdam?” 
                         Kaz blinked and his eyes cleared.
                         “Four million.”
                          “I thought that might bring you around.” He scrubbed his hands over his face, wet coughs still rattling his chest. “We made it,” he said in wonder. “Djel performs miracles.” 
                         “You don’t deserve miracles,” said Matthias with a scowl. “You    desecrated the    sacred    ash.” 
                         Kaz pushed to his feet, staggered slightly, drew in another shaky breath. “It’s a symbol, Helvar. If your god is so delicate, maybe you should get a new one. Let’s get out of here.” 
                         Nina threw up her hands. “You’re welcome, you ungrateful wretch.”"

            },
            new TextEntryEntity
            {
                TextId = 18,
                Text = @"Richard walked the length of the platform. Then he sat down on a bench and waited for something to happen.
                         Nothing happened.
                         He rubbed his head and felt slightly sick. There were footsteps on the platform, near him, and he looked up to see a prim little girl walking past him, hand in hand with a woman who looked like a larger, older version of the girl. They glanced at him and then, rather obviously, looked away. “Don’t get too near to him, Melanie,” advised the woman, in a very audible whisper.
                         Melanie looked at Richard, staring in the way children stare, without embarrassment or self-consciousness. Then she looked back at her mother. “Why do people like that stay alive?” she asked, curiously.
                         “Not enough guts to end it all,” explained her mother.
                         Melanie risked another glance at Richard. “Pathetic,” she said. Their feet pattered away down the platform, and soon they were gone. He wondered if he had imagined it. He tried to remember why he was standing on this platform. Was he waiting for a Tube train? Where was he going? He knew the answer was somewhere in his head, somewhere close at hand, but he could not touch it, could not bring it back from the lost places. He sat there, alone and wondering. Was he dreaming? With his hands he felt the hard red plastic seat beneath him, stamped the platform with mud-encrusted shoes (where had the mud come from?), touched his face . . . No. This was no dream. Wherever he was, was real. He felt odd: detached, and depressed, and horribly, strangely saddened. Someone sat down next to him. Richard did not look up, did not turn his head.
                         “Hello,” said a familiar voice. “How are you, Dick? You all right?”
                         Richard looked up. He felt his face creasing into a smile, hope hitting him like a blow to the chest. “Gary?” he asked, scared. Then, “You can see me?”
                         Gary grinned. “You always were a kidder,” he said. “Funny man, funny.”
                         Gary was wearing a suit and tie. He was clean-shaven, and had not a hair out of place. Richard realized what he must look like: muddy, unshaven, rumpled . . . . “Gary? I . . . listen, I know what I must look like. I can explain.” He thought for a moment. “No . . . I can’t. Not really.”
                         “It’s okay,” said Gary reassuringly. His voice was soothing, sane. “Not sure how to tell you this. Bit awkward.” He paused. “Look,” he explained. “I’m not really here.”
                         “Yes, you are,” said Richard.
                         Gary shook his head, sympathetically. “No,” he said. “I’m not. I’m you. Talking to yourself.”
                         Richard wondered vaguely if this was one of Gary’s jokes. “Maybe this will
                         help,” said Gary. He raised his hands to his face, pushed at it, molded, shaped. His face oozed like warm Silly Putty.
                         “Is that better?” said the person who had been Gary, in a voice that was jarringly familiar. Richard knew the new face: he had shaved it most weekday mornings since he had left school; he had brushed its teeth, combed its hair, and, on occasion, wished it looked more like Tom Cruise’s, or John Lennon’s, or anyone else’s, really. It was, of course, his face. “You’re sitting on Blackfriars Station at rush hour,” said the other Richard, casually. “You’re talking to yourself. And you know what they say about people who talk to themselves. It’s just that you’re starting to edge a little closer to sanity, now.”"
            },
            new TextEntryEntity
            {
                TextId = 19,
                Text = @"Colm threw down the lump of felt that had been his hat. “I don’t understand any of this. Why would you bring me to this horrible place? Why were we shot at? What has become of your studies? What has become of you?” 
                         “It was my fault,” Wylan blurted. Every eye turned to him. “He uh … he was concerned about the bank loan, so he put his studies on hold to work with a …”
                          “Local gunsmith,” Nina offered. 
                         “Yes!” said Wylan eagerly. “A gunsmith! And then I … I told him about a deal—” 
                         “They were swindled,” Kaz said. His voice was as cold and steady as ever, but he held himself stiffly, as if walking over uncertain ground. 
                         “They were offered a business opportunity that seemed too good to be true.” Colm slumped into a chair. “If it seems that way, then—” 
                         “It probably is,” said Kaz. Nina had the strangest sense that for once he was being sincere.
                          “Did you and your brother lose everything?” Colm asked Wylan. 
                         “My brother?” Wylan asked blankly. 
                         “Your twin brother ,” Kaz said with a glance at Kuwei, who sat quietly observing the proceedings. “Yes. They lost everything. Wylan’s brother hasn’t spoken a word since.” 
                         “Does seem the quiet type,” Colm said. “And you are all … students?”
                          “Of a sort,” said Kaz. “Who spend your free hours in a graveyard. Can we not go to the authorities? Tell them what happened? These swindlers may have other victims.” 
                         “Well—” Wylan began, but Kaz silenced him with a look. A strange hush fell in the tomb. Kaz took a seat at the table. 
                         “The authorities can’t help you,” he said. “Not in this city.” 
                         “Why not?” “Because the law here is profit. Jesper and Wylan tried to take a shortcut. The watch won’t so much as wipe their tears. Sometimes, the only way to get justice is to take it for yourself.” 
                         “And that’s where you come in.” Kaz nodded. “We’re going to get your money. You won’t lose your farm.” 
                         “But you’re going to step outside the law to do it,” Colm said. He shook his head wearily. “You barely look old enough to graduate.” 
                         “Ketterdam was my education. And I can tell you this: Jesper never would have turned to me for help if he’d had anywhere else to go.” 
                         “You can’t be so bad, boy,” said Colm gruffly. “You haven’t been alive long enough to rack up your share of sin.” 
                         “I’m a quick study.”
                          “Can I trust you?”
                          “No.” 
                         Colm took up his crumpled hat again. “Can I trust you to help Jesper through this?” 
                         “Yes.” 
                         Colm sighed. He looked around at all of them. Nina found herself standing up straighter. “You lot make me feel very old.” 
                         “Spend a little more time in Ketterdam,” said Kaz. “You’ll feel ancient.”"
            },
            new TextEntryEntity
            {
                TextId = 20,
                Text = @"""He's awake,"" he observed. Again his finger lifted lazily. ""Verde. You may have him. But have a care to his nose. Leave his face alone. The rest of him is easily covered.""
 
                         Verde devoted some little time to hauling me to my feet so he could knock me down again. I wearied of that repetition long before he did. The floor did as much damage as his fists. I could not seem to keep my feet under me, nor lift my arms to shield myself. I retreated inside myself, smaller and smaller, huddling there until sheer physical pain would force me to alertness and make me struggle again. Usually just before I passed out again. I became aware of another thing. Regal's enjoyment. He did not want to bind me and cause me pain. He wanted to watch me struggle, to see me attempt to fight back and fail. He watched his guard, too, noting, no doubt, which ones turned their eyes away from this sport. He used me to take their measure. I forced myself not to care that he took pleasure from my pain. All that truly mattered was keeping my walls up and keeping Will out of my head. That was the battle I had to win.
 
                         The fourth time I awoke, I was on the floor of my cell. A terrible snuffling, wheezing sound was what had wakened me. It was the sound of my breathing. I remained where they had dumped me. After a time I lifted a hand and pawed Brawndy's cloak down from the bench. It fell partially atop me. I lay a time longer. Regal's guards had listened to him. Nothing was broken. Everything hurt, but no bones were broken. All they had given me was pain. Nothing I could die from.
 
                         I crawled over to my water. I will not enumerate the pains it cost for me to lift it and drink. My initial attempts to defend myself had left my hands swollen and sore. I tried vainly to keep the edge of the water pot from bumping against my mouth. Finally, I managed to drink. The water strengthened me, to make me all the more aware of everywhere I hurt. My half loaf of bread was there as well. I stuck the end of it in what was left of my water, and then sucked the soaked bread from the loaf as it softened. It tasted like blood. Bolt's initial battering of my head had loosened teeth and cut my mouth. I was aware of my nose as an immense area of throbbing pain. I could not bring myself to touch it with my fingers. There was no pleasure in eating, only a partial relief from the hunger that clawed at me alongside my pain."
            }
        );
    }

    public static void SeedGroups(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GroupEntity>().HasData(
           new GroupEntity
           {
               GroupId = 1,
           },
            new GroupEntity
            {
                GroupId = 2,
            }, new GroupEntity
            {
                GroupId = 3,
            }, new GroupEntity
            {
                GroupId = 4,
            }, new GroupEntity
            {
                GroupId = 5,
            });
    }

    public static void SeedVariants(this ModelBuilder modelBuilder)
    {
        // read variants from Variants.csv
        using (var reader = new StreamReader($".{Path.DirectorySeparatorChar}Variants.csv"))
        {
            List<string> listA = new List<string>();
            List<string> listB = new List<string>();
            int count = 1;
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                var variantEntity = new VariantEntity()
                {
                    TotalCount = 0,
                    VariantId = count,
                    Text1Id = int.Parse(values[0]),
                    Text2Id = int.Parse(values[1]),
                    Text3Id = int.Parse(values[2]),
                    Text4Id = int.Parse(values[3]),
                    Text5Id = int.Parse(values[4]),
                    Text6Id = int.Parse(values[5]),
                    Text7Id = int.Parse(values[6]),
                    Text8Id = int.Parse(values[7]),
                };

                modelBuilder.Entity<VariantEntity>().HasData(variantEntity);

                count++;
            }
        }
    }
}
