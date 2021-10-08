# Symphony
--------------------------------------------------------------------
## Admin account
  email
  
    admin@symphony.com
  password:
  
    Admin1234
--------------------------------------------------------------------
## Ai làm xong nhánh nào thì nhớ xóa nha.
--------------------------------------------------------------------
## Cách thêm email để kích hoạt tài khoản:
  Mở cmd hoặc terminal cd vào Symphony\Symphony.BlazorServerApp và paste:
    
    dotnet user-secrets set SendGridKey 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
  Sẽ hiện: Successfully saved SendGridKey to the secret store.
--------------------------------------------------------------------
--------------------------------------------------------------------
## Cách đăng nhập bằng Google:
  Mở cmd hay terminal lên, cd vào Symphony\Symphony.BlazorServerApp và paste:
    
    dotnet user-secrets set "Authentication:Google:ClientId" "467987195488-rr07c3kvabgab04v47nufc4oji6eph7u.apps.googleusercontent.com"
    
    dotnet user-secrets set "Authentication:Google:ClientSecret" "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"
    
  Sẽ hiện: Successfully saved ... to the secret store.
--------------------------------------------------------------------
