# Symphony

--------------------------------------------------------------------
## Cách thêm email để kích hoạt tài khoản:
  ### Mở cmd hay terminal lên : 
    Paste: 
      dotnet user-secrets set SendGridKey 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
    Sẽ hiện: 
      Successfully saved SendGridKey to the secret store.
      
  ### Vô Symphony.Services\Services\EmailSenderService\EmailSeder.cs
    Thay bằng email của mình vào chỗ:
       /*
       * Change to your email address to get confirmation email.
       */
--------------------------------------------------------------------
