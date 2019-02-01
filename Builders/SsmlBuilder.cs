﻿using Alexa.NET.Response;

namespace ASMRDarling.API.Builders
{
    public class SsmlBuilder
    {
        const string LaunchAudioSpeech = "<speak><amazon:effect name='whispered'><prosody rate='slow'><p>Hey,</p><p>it's me.</p><p>ASMR Darling.</p><p>To begin,</p><p>you can say things like,</p><p>play 10 triggers to help you sleep,</p><p>or just say play 10 triggers.</p></prosody></amazon:effect></speak>";
        const string LaunchVideoSpeech = "<speak><amazon:effect name='whispered'><prosody rate='slow'><p>Hey,</p><p>it's me.</p><p>ASMR Darling.</p><p>To play a clip,</p><p>you can tap any of the thumbnails on the right.</p><p>Enjoy.</p></prosody></amazon:effect></speak>";
        const string ExceptionAudioSpeech = "<speak><amazon:effect name='whispered'><prosody rate='slow'>Sorry, I didn't get your intention, can you please tell me one more time?.</prosody></amazon:effect></speak>";

        const string HelpAudioSpeech = "<speak><amazon:effect name='whispered'><prosody rate='slow'>You can say list, or options to hear about ASMR recordings that I can offer.</prosody></amazon:effect></speak>";


        public static SsmlOutputSpeech BuildSpeech(string speech)
        {
            return new SsmlOutputSpeech() { Ssml = speech };
        }


        public static SsmlOutputSpeech LaunchSpeech(bool? hasDisplay)
        {
            if (hasDisplay == true)
                return new SsmlOutputSpeech() { Ssml = LaunchVideoSpeech };
            else
                return new SsmlOutputSpeech() { Ssml = LaunchAudioSpeech };
        }


        public static SsmlOutputSpeech ExceptionSpeech()
        {
            return new SsmlOutputSpeech() { Ssml = ExceptionAudioSpeech };
        }


        public static SsmlOutputSpeech HelpSpeech()
        {
            return new SsmlOutputSpeech() { Ssml = HelpAudioSpeech };
        }
    }
}