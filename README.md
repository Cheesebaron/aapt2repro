# aapt2repro

Adding `<AndroidUseAapt2>True</AndroidUseAapt2>` to the debug configuration makes this App break with an exception at runtime, due to not finding resources. Seems like aapt2 isn't correctly adding these at build time.