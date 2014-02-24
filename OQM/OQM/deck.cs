using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;


namespace OQM
{
    public class place
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value;}
        }
        private string link;
        public string Link
        {
            get { return link; }
            set { link = value; }
        }
        private BitmapImage img;
        public BitmapImage BitImg
        {
            get { return img; }
            set { img = value;}
        }

        public place(string _name)
        {
            
            Name = _name;
            Link = "/OQM;component/fourche.png";
            BitImg = new BitmapImage(new Uri("/OQM;component/fourche.png", UriKind.Relative));
        }
        public place(string _name, string path)
        {
            Name = _name;
            Link = path;
            BitImg = new BitmapImage(new Uri(path));
        }
    }

    public class carte
    {
        private string titre;
        public string Titre
        {
            get { return titre; }
            set { titre = value; }
        }
        private string path;
        public string Path
        {
            get { return path; }
            set { path = value; }
        }
        private string type;
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        private string content;
        public string Content
        {
            get { return content; }
            set { content = value; }
        }
        private BitmapImage img;
        
        public BitmapImage BitImg
        {
            get { return img; }
            set { img = value; }
        }
        public carte(string _titre, string _path, string _type, string _content)
        {
            Titre = _titre;
            Path = _path;
            Type = _type;
            Content = _content;
            if (!_path.Contains("/OQM;component/"))
                BitImg = new BitmapImage(new Uri(Path));
            else
                BitImg = new BitmapImage(new Uri(Path, UriKind.Relative));
        }
    }

    public class deck
    {
        private ObservableCollection<place> placelist = new ObservableCollection<place>();
        public ObservableCollection<place> Placelist
        {
            get
            {
                return placelist;
            }

            set
            {
                placelist = value;
            }
        }
        private ObservableCollection<carte> cards = new ObservableCollection<carte>();
        public ObservableCollection<carte> Cards
        {
            get { return cards; }
            set { cards = value;}
        }
        private ObservableCollection<carte> extra = new ObservableCollection<carte>();
        public ObservableCollection<carte> Extra
        {
            get { return extra; }
            set { extra = value; }
        }
        private static ObservableCollection<carte> hand = new ObservableCollection<carte>();
        public ObservableCollection<carte> Hand
        {
            get { return hand; }
            set { hand = value; }
        }
        private Random r = new Random();
        public int index;
        public deck()
        {
            Cards.Add(new carte("Pas d'accord !","/OQM;component/illus/no.jpg","Action","Cette carte annule la carte lieu ou action précédemment jouée."));
            Cards.Add(new carte("Pas d'accord !", "/OQM;component/illus/no.jpg", "Action", "Cette carte annule la carte lieu ou action précédemment jouée."));
            Cards.Add(new carte("Pas d'accord !", "/OQM;component/illus/no.jpg", "Action", "Cette carte annule la carte lieu ou action précédemment jouée."));
            Cards.Add(new carte("Dernier mot.", "/OQM;component/illus/derniermot.jpg", "Action", "Pour jouer cette carte il faut qu'il y ait exactement 2 cartes dans votre main et que l'une d'elle soit une carte lieu. Cette carte ne peut pas être annulé. Suite à cette carte, jouez une carte lieu. La partie s'arrête."));
            Cards.Add(new carte("Dernier mot.", "/OQM;component/illus/derniermot.jpg", "Action", "Pour jouer cette carte il faut qu'il y ait exactement 2 cartes dans votre main et que l'une d'elle soit une carte lieu. Cette carte ne peut pas être annulé. Suite à cette carte, jouez une carte lieu. La partie s'arrête."));
            Cards.Add(new carte("Bof...", "/OQM;component/illus/bof.jpg", "Action", "Cette carte annule une carte d'action précédemment jouée."));
            Cards.Add(new carte("Bof...", "/OQM;component/illus/bof.jpg", "Action", "Cette carte annule une carte d'action précédemment jouée."));
            Cards.Add(new carte("Joker","/OQM;component/illus/joker.png","Lieu","Dites un lieu. N'importe lequel."));
            Cards.Add(new carte("Joker", "/OQM;component/illus/joker.png", "Lieu", "Dites un lieu. N'importe lequel."));
            Cards.Add(new carte("Joker", "/OQM;component/illus/joker.png", "Lieu", "Dites un lieu. N'importe lequel."));
            Cards.Add(new carte("Oh non pas ca...", "/OQM;component/illus/notagain.png", "Action", "Cette carte annule la carte lieu précédemment jouée, vous devez jouer une carte lieu pour la remplacer."));
            Cards.Add(new carte("Oh non pas ca...", "/OQM;component/illus/notagain.png", "Action", "Cette carte annule la carte lieu précédemment jouée, vous devez jouer une carte lieu pour la remplacer."));
            Cards.Add(new carte("Oh non pas ca...", "/OQM;component/illus/notagain.png", "Action", "Cette carte annule la carte lieu précédemment jouée, vous devez jouer une carte lieu pour la remplacer."));
            Cards.Add(new carte("Puisque c'est comme ca, j'me tire !", "/OQM;component/illus/jmetire.png", "Action", "Vous sortez du jeu."));
            Cards.Add(new carte("Puisque c'est comme ca, j'me tire !", "/OQM;component/illus/jmetire.png", "Action", "Vous sortez du jeu."));
            Cards.Add(new carte("La bas c'est trop cher.", "/OQM;component/illus/tropcher.png", "Action", "Cette carte annule la carte lieu précédemment jouée, vous devez jouer une carte lieu ou l'on mange moins cher pour la remplacer."));
            Cards.Add(new carte("La bas c'est trop cher.", "/OQM;component/illus/tropcher.png", "Action", "Cette carte annule la carte lieu précédemment jouée, vous devez jouer une carte lieu ou l'on mange moins cher pour la remplacer."));
            Cards.Add(new carte("Moi je suis d'accord !","/OQM;component/illus/plusone.png","Action","Cette carte annule une carte action qui annulais une carte."));
            Cards.Add(new carte("Moi je suis d'accord !", "/OQM;component/illus/plusone.png", "Action", "Cette carte annule une carte action qui annulais une carte."));
            Cards.Add(new carte("Echange","/OQM;component/illus/trade.jpg","Action","Echangez votre téléphone avec le joueur de votre choix. (Pour le jeu hein...)"));
            Cards.Add(new carte("Echange", "/OQM;component/illus/trade.jpg", "Action", "Echangez votre téléphone avec celui du joueur de votre choix. (Pour le jeu hein...)"));
            Cards.Add(new carte("Roulement", "/OQM;component/illus/roulette.png", "Action", "Chaque joueur fait passer son téléphone à son voisin de gauche."));
            Cards.Add(new carte("Roulement", "/OQM;component/illus/roulette.png", "Action", "Chaque joueur fait passer son téléphone à son voisin de gauche."));
            Cards.Add(new carte("Roulement", "/OQM;component/illus/roulette.png", "Action", "Chaque joueur fait passer son téléphone à son voisin de gauche."));
            Cards.Add(new carte("Moi vivant, jamais!","/OQM;component/illus/never.png","Action","Cette carte annule la carte lieu précédemment jouée. Cette carte ne peut pas être annulé sauf si un joueur a \"Puisque c'est comme ca, j'me tire!\" dans ce cas vous sortez du jeu et la carte \"Puisque c'est comme ca, j'me tire!\" est utilisée."));
            Cards.Add(new carte("Moi vivant, jamais!", "/OQM;component/illus/never.png", "Action", "Cette carte annule la carte lieu précédemment jouée. Cette carte ne peut pas être annulée sauf si un joueur a \"Puisque c'est comme ca, j'me tire!\" dans ce cas vous sortez du jeu et la carte \"Puisque c'est comme ca, j'me tire!\" est utilisée."));
            Cards.Add(new carte("Télépathie","/OQM;component/illus/telepathie.jpg","Action","Choisissez un joueur, regardez son téléphone vous pouvez jouer une carte comme si c'etait la votre."));
            Cards.Add(new carte("Télépathie", "/OQM;component/illus/telepathie.jpg", "Action", "Choisissez un joueur, regardez son téléphone vous pouvez jouer une carte comme si c'etait la votre."));
            Cards.Add(new carte("Télépathie", "/OQM;component/illus/telepathie.jpg", "Action", "Choisissez un joueur, regardez son téléphone vous pouvez jouer une carte comme si c'etait la votre."));
            Cards.Add(new carte("Pas encore !", "/OQM;component/illus/again.png", "Action", "Cette carte annule la carte lieu précédemment jouée si vous y avez mangé dans les 3 deniers jours."));
            Cards.Add(new carte("Pas encore !", "/OQM;component/illus/again.png", "Action", "Cette carte annule la carte lieu précédemment jouée si vous y avez mangé dans les 3 deniers jours."));
            Cards.Add(new carte("C'est moi qu'ai la plus grosse.", "/OQM;component/illus/dsk.jpg", "Action", "Si vous etes un homme, cette carte annule la carte action précédemment jouée, elle ne peut pas être annulée. Si vous etes une femme ca fait la même chose, c'est juste moins drôle."));
            Cards.Add(new carte("C'est moi qu'ai la plus grosse.", "/OQM;component/illus/dsk.jpg", "Action", "Si vous etes un homme, cette carte annule la carte action précédemment jouée, elle ne peut pas être annulée. Si vous etes une femme ca fait la même chose, c'est juste moins drôle."));
            Cards.Add(new carte("Ouais, mais j'suis Veget' tu vois...", "/OQM;component/illus/YEAH.jpg", "Action", "Cette carte annule le lieu précédemment joué. Cette carte est annulée si le joueur à votre droite cite 2 plats végétariens à la carte de l'établissement ciblé. (même s'il en est capable, il n'est pas obligé de le faire)"));
            Cards.Add(new carte("Ouais, mais j'suis Veget' tu vois...", "/OQM;component/illus/YEAH.jpg", "Action", "Cette carte annule le lieu précédemment joué. Cette carte est annulée si le joueur à votre droite cite 2 plats végétariens à la carte de l'établissement ciblé. (même s'il en est capable, il n'est pas obligé de le faire)"));
        }

        public void make_extra_cards()
        {
            foreach (place p in Placelist)
            {
                extra.Add(new carte(p.Name,p.Link,"Lieu","Miam miam..."));
                extra.Add(new carte(p.Name, p.Link, "Lieu", "Miam miam..."));
                extra.Add(new carte(p.Name, p.Link, "Lieu", "Miam miam..."));
                extra.Add(new carte("Oh non pas "+p.Name, p.Link, "Action", "Cette carte annule la carte " + p.Name));
            }
        }

        public void remove_extra_cards()
        {
            Extra.Clear();
        }

        public void remove_hand_cards()
        {
            Hand.Clear();
        }
        
        public void draw_random_card()
        {
            Hand.Add(Cards[r.Next(Cards.Count)]);
        }

        public void draw_random_extra()
        {
            Hand.Add(Extra[r.Next(Extra.Count)]);
        }
    }
}
