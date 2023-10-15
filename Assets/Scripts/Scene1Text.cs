using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Scene1Text : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    TextMeshProUGUI text;
    List<string> texts = new List<string>();
    IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
        text = canvas.GetComponentInChildren<TextMeshProUGUI>();
        canvas.enabled = false;
        texts.Add("Le sujet de l’intelligence artificielle est sur toutes les lèvres durant ces derniers mois. Cette nouvelle technologie révolutionnaire a le potentiel de changer la face du monde, pour le meilleur et pour le pire. Mais que savez-vous réellement sur l’intelligence artificielle? Ces algorithmes sont si complexes que même leurs développeurs les considèrent parfois comme des «boîtes noires» dont il est impossible de comprendre le fonctionnement réel et, par conséquent, dont il est impossible de prévoir l’évolution. C’est pour cette raison que plusieurs experts dans le domaine ont signé une lettre ouverte demandant l’arrêt du développement de la technologie pour 6 mois, le temps de s’assurer de la sécurité de ces machines. Plusieurs questions troublantes y sont posées telles que : «Devrions-nous développer des esprits non-humains qui pourraient éventuellement nous surpasser en nombre et en intelligence, nous rendre inutiles et nous remplacer?");
        texts.Add("Bien sûr, il est impossible d’arrêter le progrès. Cependant, le but de cette lettre était d’ouvrir la discussion sur les risques relatifs à l’intelligence artificielle et les enjeux éthiques liés à cette technologie. Par contre, il est difficile pour un profane de suivre le débat sans les connaissances techniques requises pour comprendre les subtilités de ces machines. C’est pourquoi nous avons décidé de créer un jeu dans lequel vous pourrez découvrir par vous-même différents aspects de l’intelligence artificielle ainsi que plusieurs enjeux éthiques importants qui y sont liés. À la fin de cette aventure, vous serez en mesure de participer à la discussion importante concernant le futur de cette technologie qui nous affectera tous. Alors, êtes-vous prêt à vous lancer au cœur de ce monde tout aussi merveilleux qu’effrayant?\r\n");
        texts.Add("Artificial intelligence has been a hot topic these last few months. This new groundbreaking technology  has the potential to change the world for better or for worse. But, what do you really know about artificial intelligence? These algorithms are so complex that even the developers making that technology consider them like “black boxes” that are incomprehensible, thus having an unpredictable outcome. It's for this reason that a lot of experts in the domain signed an open letter asking to cease the development of that technology for six months, in order to assure the security of these machines. A lot of troubling questions are asked in the letter like : “Should we develop nonhuman minds that might eventually outnumber, outsmart, obsolete and replace us?”");
        texts.Add("Of course, progress is unstoppable. However, this letter’s purpose was to open a conversation over the risks related to artificial intelligence and the ethical issues linked to this technology. On the other hand, it is difficult for the uninitiated to follow the debate without the required technical knowledge to grasp the intricacy of these machines. That is the main reason why we decided to create a game in which you can discover by yourself different aspects of artificial intelligence as well as several important ethical issues related to it. By the end of this adventure, you will be able to participate in more important discussions regarding this technology’s future, a technology that will affect us all. So, are you ready to dive into this wonderfully frightening world?\r\n");
        texts.Add("Artificial intelligence or AI, as it is often called, is a term widely used and for a variety of computer programs. But not all computer programs are “intelligent”. When we refer to AI, we usually refer to an algorithm that is able to make decisions based on a series of inputs. Here is a definition by IBM : “At its simplest form, artificial intelligence is a field, which combines computer science and robust datasets, to enable problem-solving.”[3] Artificial intelligence softwares are designed to think and act like humans or, ideally, think and act rationally.\r\n");
        texts.Add("There are different types of such algorithms. Most of them are machine learning algorithms. We use the term “learning”, because these algorithms are optimized over a great number of iterations through a data set. To be more technical, “they consist of three parts: a decision process, an error function and a model optimization process.”[5] Machine learning algorithms can be linear regression models, logistic regression or decision trees, which are all types of algorithms that can be described as big mathematical functions.\r\n");
        texts.Add("Another type of machine learning algorithm is artificial neural networks. Another term to describe them is deep learning algorithms. These models try to mimic the human brain, which is composed of billions of neurons that are linked in a certain way that allows intelligence to emerge.\r\n");
        texts.Add("It is important to understand that most problems do not require complex neural networks to be solved. But for some problems, it is impossible to “hard code” all the possibilities to ensure that the program always works. For example, imagine we wanted to make a program which tells if a certain image contains a cat. We could try to make the program analyze certain characteristics of cats like does it have four legs, two ears, fur, etc. But if we code a program with these exact instructions, it would say that the image contains a cat if we present an image of a dog, because a dog also has the same characteristics.\r\n");
        texts.Add("That is where a neural network becomes a great idea because it can handle new and unorganized data with greater accuracy than “hard coded” programs. A biological brain can make the difference between a dog and a cat because it has seen many examples of both and is able to extrapolate to new situations. Neural networks, trained with enough data, are able to do the same.");
        texts.Add("Move to the room on your right to discover what a neural network might look like.\r\n");
        texts.Add("Now that you have understood the bases of neural networks, you might wonder how developers manage to arrange the weight and bias of each neuron in order to achieve the desired goal, considering that the biggest networks can contain up to hundreds of neurons. The answer is that they don’t do it themselves. In fact, it would be nearly impossible to figure out the required combination of weights and biases in a big network due to how abstract and complex it is.\r\n");
        texts.Add("In practice, deep neural networks learn by themselves. Developers train neural networks on large data sets. The idea is quite simple : you feed the algorithm with an input and let it process it to give an output. For the training data, there is an expected output associated with every input. The output of the algorithm is then compared to the expected output in a loss function, which essentially calculates how much the neural network prediction is wrong compared to the expected answer. Then, based on the result of the loss function, there is a combination of complex techniques, called backpropagation and gradient descent, which slightly modify the weights and biases of the network in order to improve the accuracy of the network in future iterations.\r\n");
        texts.Add("The training process of a neural network can be very long and requires enormous quantities of data. That is why we often hear that data is the new oil. Another thing to take into consideration is that the data set on which the AI has been trained on will greatly influence its outputs. For example, a facial recognition algorithm which was trained mostly on white Americans had difficulties detecting faces which were not similar to those in the training data set, like Black people. Often, what takes the biggest amount of time when developing a new AI system is gathering enough data, labeling it correctly and making sure that this data covers all the possible situations the AI might need to handle.\r\n");
        texts.Add("Another thing you might have realized when playing with the networks in the previous rooms is how complex these algorithms can become. With only 3 layers and a low number of neurons, it can be really hard to understand how each input affects the next layer and, in turn, the output. With more layers and more neurons, it is practically impossible to understand the network in its entirety. This is why neural networks are often called “black boxes”. The developers know what comes into the network but have no idea how it is processed and how the network arrives at a certain output. For example, if you feed an image recognition algorithm an image of a cat and it says it is a bus, it is hard to know what went wrong. \r\n");
        texts.Add("In some cases, it is not really important to know how the algorithm arrived at a certain output, but in other cases, it may be necessary to use other algorithms which are way easier to interpret like decision trees. Here is a great example of such a situation : “a lot of banks don’t use neural networks to predict whether a person is creditworthy — they need to explain to their customers why they didn’t get the loan, otherwise the person may feel unfairly treated.”[4] In the long run, we might not always want to take advice from artificial neural networks, because we have no idea how they came up with those advices and it is important to know the reflexion process before taking an important decision. ");
        texts.Add("At the same time, it is understandable that artificial neural networks are hard to pierce through, because they try to mimic biological neural networks which we still have minimal knowledge about. For example, when you come up with an idea, it is impossible to pinpoint what neurons in your brain fired at which moments to create this idea. For humans, although, people are usually able to explain their reasoning to others when asked to do so. This is something scientists are still working on for AI systems.\r\n");
        texts.Add("All things considered, neural networks have some big flaws. They act like a “black box”, they require enormous quantities of data to train on, they usually take a big amount of time to develop and they are computationally expensive. But, at the same time, they have a lot of advantages that make them a great solution to many problems. In fact, their ability to handle unorganized data with great accuracy and think abstractly make them essential for some challenging situations.");
        texts.Add("AI systems are used in a variety of cases today. Some well-known examples are speech recognition, customer service chatbots, computer vision, recommendation engines and automated stock trading. They are also used in natural language processing, which we will explore in detail later on your journey. In all these domains, the input is never truly the same, but a neural network can generalize a situation and arrive at the right conclusion.");
        texts.Add("As you continue your journey through this world, you will encounter many ethical problems that arise from the use of AI algorithms. Sometimes, those problems are directly linked to the very nature of neural networks, so keep their structure in mind while you advance to the next chapter.");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            canvas.enabled = false;
            StopAllCoroutines();
        }
    }

    public void ShowText(int index)
    {
        canvas.enabled = true;
        text.text = "";
        coroutine = WriteText(index);
        StartCoroutine(coroutine);
    }

    IEnumerator WriteText(int index)
    {
        foreach (char c in texts[index])
        {
            text.text += c;
            yield return new WaitForSeconds(0.01f);
        }


    }
}
