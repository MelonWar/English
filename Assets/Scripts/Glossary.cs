using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

public static class Glossary
{
    public static Dictionary<string, string> glossary = new Dictionary<string, string>
    {
        {"Algorithm", "An algorithm is a set of commands that must be followed for a computer to perform calculations or other problem-solving operations. Basically any computer program can be called an algorithm because they all follow finite sets of rules in order to reach a certain output, even the most complicated of AIs. However, the term algorithm is usually used to talk about more rigid computer programs, as AIs can usually change their internal algorithms during their training phase, even if they do so by following sets of instructions."  },
        {"Artificial General Intelligence","Artificial General Intelligence represents AI that could perform in a lot of different tasks with capacities similar or superior to humans. It is a hypothetical concept in the sense that it doesn’t exist yet and experts are not even sure if it could happen one day." },
        {"Artificial Intelligence","Artificial Intelligence is a computer or software that can do the work of human intelligence. " },
        {"Artificial Neural Network","An artificial neural network is a system used in the domain of artificial intelligence as the pillar of its production. It is a system with neurons, inputs and outputs. It serves as a sorting mechanism for artificial intelligence." },
        {"Backpropagation","Backpropagation is a method commonly used to train and optimize artificial neural networks. Through many iterations, this technique adjusts the weights and biases of the neural network from the last layer to the first in order to minimize the error of the algorithm." },
        {"Black box","Concerning the AI subject, a black box describes the situation when a person can’t see the processing of information in an AI." },
        {"Chatbot","A Chatbot is a software or AI that has one objective which is to communicate or make a dialog with people using a certain interface." },
        {"Completion","In the case of language models, completion is the act of predicting the end of a sentence based on the beginning of it. It is used for emails, google searches, text editors and more." },
        {"Corpus","A collection of written and spoken material. In the field of AI, a corpus is defined as the data on which the AI was trained. The AI’s final version will greatly depend on the corpus it has been trained on." },
        {"Cryptocrime","Cryptocrime is a term used to describe a crime regarding cryptocurrency which is currency online. The term is used in our project in the deepfake text, because we explain how deepfakes are used for cryptocrime" },
        {"Cybercrime","A crime that was done through the internet. One of the main features of a cybercrime is the theft of personal data using multiple technologies to breach through many layers of informatic defenses." },
        {"DALL-E","DALL-E is the name given to an AI made by Open source, the same company that made chat gpt. This AI has the particular feat of making any type of image from a prompt." },
        {"Data","Data refers to information, especially facts or numbers, collected to be examined and considered and used to help decision-making. It also refers to information in an electronic form that can be stored and used by a computer. Machine Learning algorithms require a lot of data to function properly. Data can also be bought or sold, and with the rise of AI, it will likely gain a lot of value in the next few years." },
        {"Database","A database is a set of data conserved in a computer." },
        {"Decision tree","Algorithm used to visually conceive the decisions made for the AI to help it see the possible predictions. This concept is important in the domain of machine learning." },
        {"Deep Blue","Deep blue is the first machine/AI that won a chess tournament against a human." },
        {"Deepfakes","A deepfake is a technique used in the media to alter videos or audio files in order to make the alterations look as real as possible. This sort of action is made possible by AI and is used in its majority to spread misinformation or for pranks." },
        {"Deep learning","Deep learning is a type of machine learning that uses artificial neural networks with multiple layers of processing in order to extract progressively higher level features from data." },
        {"Feeding","In the case of machine learning, the expression “feeding an algorithm” with data means giving the system enough training data so it can learn and improve." },
        {"Function","A function in coding is a certain group of code and code language that work in order to do a specific task in the script. Generally, like any type of function in mathematics, the functions in programming receives something and treats the information to give something in return." },
        {"Generative AI","Generative artificial intelligence describes algorithms that can be used to create new content, including audio, code, images, text, simulations, and videos. They usually create this content using a prompt given by a human." },
        {"GPT","GPT is an acronym that stands for Generative Pre-traintre Transformer. That acronym describes a complex group of neural networks that work for LLMs. This name is used for the famous chatbot AI." },
        {"Input","Set of information taken by an algorithm or a program in order to treat it for a certain purpose." },
        {"Iteration","An iteration is a repetition or an example of a certain subject. In computer programming an iteration is a variable that has a certain group of code affiliated to it." },
        {"Machine Learning","ML or machine learning covers a broad range of computer systems that are able to learn and adapt without following explicit instructions. They achieve that by using algorithms and statistical models to analyze and draw inferences from patterns in data." },
        {"Natural language","Natural language is language that is commonly used by humans, for example : english. It is used in opposition to computer language like code and compiled instructions. Processing natural language is a key part of some AIs, because it allows them to interact with humans, not just programmers that know this specific system." },
        {"Neurons","A neuron is a node connected to another node. In our case, neurons are used in the explanation of artificial neural networks to show how they can be used in AI making and machine learning." },
        {"Prompt","An instruction given to an artificial intelligence by a human using natural language rather than computer language. The output of the AI will depend on the prompt it received." },
        {"Large language models","A large language model (LLM) is a type of artificial intelligence algorithm that uses deep learning techniques combined with large data sets to understand, summarize, generate and predict new content." },
        {"NullReferenceException","A NullReferenceException is an error in programming when a variable isn’t referencing any value. The use of this term is used in the project as a sort of easter egg for people who code." },
        {"Optimization","The act of upgrading something to its best capacities. In terms of the computer and technologic domain,optimization refers to making a code or a program better. That means that the code or program in question runs faster, costs less in terms of space and so on." },
        {"Output","In the context of our project, an output is the resulting information after it got treated in an algorithm or program." },
        {"Pattern recognition","Pattern recognition is a data analysis method used in machine learning that has the goal to recognize regularities and patterns in data." },
        {"Prediction","A prediction is the action of taking an educated guess on what the answer to a certain question or problem might be. In the field of AI, many programs are prediction algorithms in the sense that they work with probabilities and try to find the most probable answer to a question without knowing if it is the right one." },
        {"Program","A coded software built by a software engineer with the objective to solve some kind of problem." },
        {"Script","A script is a folder holding code in order to do a certain function or a directive in a programming project." },
        {"Startup","A startup is a company that recently started. There are a lot of them in the field of AI because it is a relatively new one and there is a lot of innovation to be made." },
        {"Turing test","The Turing test is an evaluation of an artificial intelligence in order to know if an AI sounds human. The test was founded and named after Alan Turing." },
        {"Training data","Training data is the term used for the data or information gathered in a corpus." },
        {"Trolls","Trolls is a term used on the internet that describes people that do pranks on social media. These trolls often are ill-intended with the objective to annoy people altogether." }
    };

    public static List<string> GetWords()
    {
        return glossary.Keys.ToList<string>();
    }

    public static string HighlightText(string text)
    {
        List<string> words = GetWords();
        foreach(string word in words)
        {
            if(text.Contains(word.ToLower()))
            {
                text = Regex.Replace(text, word.ToLower(), $"<u>{word.ToLower()}</u>");
                text = Regex.Replace(text, word, $"<u>{word}</u>");
            }
        }
        return text;
    }
}
