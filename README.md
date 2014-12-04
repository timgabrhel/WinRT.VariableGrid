Variable Grid in WP8.1 Runtime Apps 
=============

This post is a continuation of my original [Uniform grid layouts](http://timgabrhel.com/blog/dynamic-grid-layouts-in-wp8-1-runtime-apps/) post. Please see it for more information and the starting point [source code](https://github.com/timgabrhel/WinRT.EffectiveResolutionGrid) for this post.

### Upgrading the model

We'll start by upgrading our existing `Item` model and `MainViewModel`'s. In the **Models** folder, create a new interface named `IVariableGridViewItem` and define two **int** properties, `Width`, and `Height`.

Read the rest on my [blog](http://timgabrhel.com/blog/variable-grid-in-wp8-1-runtime-apps)